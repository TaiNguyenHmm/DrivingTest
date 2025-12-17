using DrivingTest.Models;
using DrivingTest.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DrivingTest.Controllers
{
    public class AuthenticatorController : Controller
    {
        private readonly DrivingTestContext _context;

        public AuthenticatorController(DrivingTestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.LoginError = "Vui lòng nhập email.";
                return View("Index");
            }

            // Check lockout
            if (LoginAttemptStore.IsLocked(email, out var lockoutEnd))
            {
                var remaining = lockoutEnd?.Subtract(DateTime.UtcNow) ?? TimeSpan.Zero;
                ViewBag.LoginError = $"Tài khoản tạm thời bị khóa. Vui lòng thử lại sau {Math.Ceiling(remaining.TotalMinutes)} phút.";
                return View("Index");
            }

            string passwordHash = ComputeSha256Hash(password);

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);

            if (user != null)
            {
                // successful login -> reset attempts
                LoginAttemptStore.Reset(email);

                var activityLog = new UserActivityLog
                {
                    UserId = user.UserId,
                    ActionType = "Đăng nhập",
                    Details = $"Người dùng '{user.Username}' đã đăng nhập thành công.",
                    Timestamp = DateTime.Now
                };

                _context.UserActivityLogs.Add(activityLog);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                if (user.Role == 0) return RedirectToAction("Welcone", "Home");
                return RedirectToAction("Dashboard_Admin", "Dashboard");
            }

            // failed login -> record attempt
            var (count, isLocked, lockout) = LoginAttemptStore.RecordFailedAttempt(email, maxAttempts: 5, lockoutMinutes: 10);
            if (isLocked)
            {
                ViewBag.LoginError = "Bạn đã nhập sai quá nhiều lần. Tài khoản bị khóa trong 10 phút.";
            }
            else
            {
                var remainingAttempts = 5 - count;
                ViewBag.LoginError = $"Email hoặc mật khẩu không đúng. Còn {remainingAttempts} lần thử trước khi khóa.";
            }

            return View("Index");
        }

        // New: start registration -> send verification email, store pending registration
        [HttpPost]
        public IActionResult StartRegistration([FromBody] StartRegistrationModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });

            if (_context.Users.Any(u => u.Email == model.Email))
                return BadRequest(new { success = false, message = "Email đã tồn tại." });

            var pending = new PendingRegistration
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = ComputeSha256Hash(model.Password)
            };

            var token = RegistrationStore.Add(pending);

            // send email with verification link
            var verifyUrl = Url.Action("ConfirmRegistration", "Authenticator", new { token }, Request.Scheme);

            try
            {
                var fromAddress = new MailAddress("tainahe176053@fpt.edu.vn", "DrivingTest");
                var toAddress = new MailAddress(model.Email);
                const string fromPassword = "rnzt kafe xjhz pazo\r\n";
                const string subject = "Xác thực đăng ký DrivingTest";
                string body = $"Vui lòng xác thực email bằng cách nhấp vào link sau: {verifyUrl}\nLink sẽ hết hạn sau 1 giờ.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body }) { smtp.Send(message); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Không thể gửi email xác thực: " + ex.Message });
            }

            return Json(new { success = true, token });
        }

        // New: confirm registration
        [HttpGet]
        public async Task<IActionResult> ConfirmRegistration(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return RedirectToAction("Index");

            if (!RegistrationStore.TryRemove(token, out var pending))
            {
                TempData["RegisterError"] = "Token không hợp lệ hoặc đã hết hạn.";
                return RedirectToAction("Index");
            }

            if (_context.Users.Any(u => u.Email == pending.Email))
            {
                TempData["RegisterError"] = "Email đã tồn tại.";
                return RedirectToAction("Index");
            }

            var user = new User
            {
                Email = pending.Email,
                PasswordHash = pending.PasswordHash,
                Username = pending.Username
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var activityLog = new UserActivityLog { UserId = user.UserId, ActionType = "Xác thực đăng ký", Details = $"Người dùng '{user.Username}' đã xác thực email và hoàn tất đăng ký.", Timestamp = DateTime.Now };
            _context.UserActivityLogs.Add(activityLog);
            await _context.SaveChangesAsync();

            TempData["RegisterSuccess"] = "Xác thực thành công! Bạn có thể đăng nhập ngay bây giờ.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string confirmPassword)
        {
            // keep existing method for compatibility but we will not use it from UI now
            if (password != confirmPassword) { ViewBag.RegisterError = "Mật khẩu xác nhận không khớp."; ViewBag.ShowLogin = false; return View("Index"); }
            if (_context.Users.Any(u => u.Email == email)) { ViewBag.RegisterError = "Email đã tồn tại."; ViewBag.ShowLogin = false; return View("Index"); }

            string passwordHash = ComputeSha256Hash(password);
            var user = new User { Email = email, PasswordHash = passwordHash, Username = username };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var activityLog = new UserActivityLog { UserId = user.UserId, ActionType = "Đăng ký", Details = $"Người dùng '{user.Username}' đã đăng ký tài khoản thành công.", Timestamp = DateTime.Now };
            _context.UserActivityLogs.Add(activityLog);
            await _context.SaveChangesAsync();

            TempData["RegisterSuccess"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Index", "Authenticator");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var userIdClaim = User.FindFirst("UserId");
            var usernameClaim = User.FindFirst(ClaimTypes.Name);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                string username = usernameClaim?.Value ?? "Unknown";
                var activityLog = new UserActivityLog { UserId = userId, ActionType = "Đăng xuất", Details = $"Người dùng '{username}' đã đăng xuất.", Timestamp = DateTime.Now };
                _context.UserActivityLogs.Add(activityLog);
                await _context.SaveChangesAsync();
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Home");
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null) return Json(new { success = false, message = "Email chưa được đăng ký." });

            var rnd = new Random();
            string newPassword = rnd.Next(100000, 999999).ToString();
            user.PasswordHash = ComputeSha256Hash(newPassword);
            await _context.SaveChangesAsync();

            try
            {
                var fromAddress = new MailAddress("tainahe176053@fpt.edu.vn", "DrivingTest");
                var toAddress = new MailAddress(user.Email);
                const string fromPassword = "rnzt kafe xjhz pazo\r\n";
                const string subject = "Mật khẩu mới của bạn";
                string body = $"Mật khẩu mới của bạn là: {newPassword}";

                var smtp = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true, DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false, Credentials = new NetworkCredential(fromAddress.Address, fromPassword) };
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body }) { smtp.Send(message); }

                return Json(new { success = true, message = "Mật khẩu mới đã được gửi vào email của bạn." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Gửi email thất bại: " + ex.Message });
            }
        }

        public class ForgotPasswordModel { public string Email { get; set; } }

        public class StartRegistrationModel { public string Username { get; set; } public string Email { get; set; } public string Password { get; set; } }
    }
}
