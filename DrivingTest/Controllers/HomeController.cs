using DrivingTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DrivingTest.Controllers
{
    [Authorize] 
    public class HomeController : Controller
    {
        private readonly DrivingTestContext _context;

        public HomeController(DrivingTestContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Welcone()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            int userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Authenticator");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateProfile(string Username, string Email)
        {
            int userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return RedirectToAction("Index", "Authenticator");

            // Kiểm tra email trùng với người khác
            if (_context.Users.Any(u => u.Email == Email && u.UserId != userId))
            {
                TempData["ErrorMessage"] = "Email đã được sử dụng bởi người khác.";
                return RedirectToAction("UserProfile", "Home");
            }

            user.Username = Username;
            user.Email = Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim("UserId", user.UserId.ToString())
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
            return RedirectToAction("Welcone", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            int userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return RedirectToAction("Index", "Authenticator");

            string currentHash = ComputeSha256Hash(CurrentPassword);
            if (user.PasswordHash != currentHash)
            {
                TempData["ErrorMessage"] = "Mật khẩu hiện tại không đúng.";
                return RedirectToAction("UserProfile");
            }

            if (NewPassword != ConfirmPassword)
            {
                TempData["ErrorMessage"] = "Mật khẩu xác nhận không khớp.";
                return RedirectToAction("UserProfile");
            }

            user.PasswordHash = ComputeSha256Hash(NewPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
            return RedirectToAction("Welcone", "Home");
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        // Submit Feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitFeedback(string Title, string Message)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
                
                if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Message))
                {
                    TempData["ErrorMessage"] = "Vui lòng điền đầy đủ tiêu đề và nội dung phản hồi.";
                    return RedirectToAction("Welcone");
                }

                var feedback = new Feedback
                {
                    UserId = userId,
                    Title = Title.Trim(),
                    Message = Message.Trim(),
                    CreatedAt = DateTime.Now,
                    Status = "Chờ Xử Lý"
                };

                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Cảm ơn bạn! Phản hồi của bạn đã được gửi thành công.";
                return RedirectToAction("Welcone");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi gửi phản hồi. Vui lòng thử lại.";
                return RedirectToAction("Welcone");
            }
        }
    }
}
