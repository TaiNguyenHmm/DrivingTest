using DrivingTest.Models;
using DrivingTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DrivingTest.Controllers
{


    [Authorize(Roles = "1")]

    public class DashboardController : Controller
    {
        private readonly DrivingTestContext _context;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(DrivingTestContext context, ILogger<DashboardController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Dashboard_Admin(
            int userPage = 1,
            int questionPage = 1,
            int testPage = 1,
            int feedbackPage = 1,
            int testPageSize = 10,
            string tab = "dashboard",
            string categoryFilter = "")
        {
            // ===============================
            // USERS PAGINATION
            // ===============================
            const int userPageSize = 10;
            userPage = userPage < 1 ? 1 : userPage;

            var usersQuery = _context.Users
                .Where(u => u.Role == 0)
                .OrderBy(u => u.UserId);

            int totalUsers = await usersQuery.CountAsync();
            int totalUserPages = (int)Math.Ceiling((double)totalUsers / userPageSize);

            if (userPage > totalUserPages && totalUserPages > 0)
                userPage = totalUserPages;

            var users = await usersQuery
                .Skip((userPage - 1) * userPageSize)
                .Take(userPageSize)
                .ToListAsync();

            // ===============================
            // QUESTIONS PAGINATION WITH CATEGORY FILTER
            // ===============================
            const int questionPageSize = 8;
            questionPage = questionPage < 1 ? 1 : questionPage;

            // Get distinct categories for dropdown
            var categories = await _context.Questions
                .Where(q => !string.IsNullOrEmpty(q.Category))
                .Select(q => q.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            // Build query with optional category filter
            var questionsBaseQuery = _context.Questions.AsQueryable();
            
            if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "all")
            {
                questionsBaseQuery = questionsBaseQuery.Where(q => q.Category == categoryFilter);
            }

            var questionsQuery =
                from q in questionsBaseQuery
                join a in _context.Answers
                    on new { q.QuestionId, q.CorrectAnswer }
                    equals new { QuestionId = a.QuestionId, CorrectAnswer = a.OptionKey }
                orderby q.QuestionId
                select new QuestionWithAnswerViewModel
                {
                    ID = q.QuestionId,
                    QuestionText = q.QuestionText,
                    ImageUrl = q.ImageUrl,
                    CorrectAnswer = a.OptionText,
                    Category = q.Category
                };

            int totalQuestions = await questionsQuery.CountAsync();
            int totalQuestionPages = (int)Math.Ceiling((double)totalQuestions / questionPageSize);

            if (questionPage > totalQuestionPages && totalQuestionPages > 0)
                questionPage = totalQuestionPages;

            var questionList = await questionsQuery
                .Skip((questionPage - 1) * questionPageSize)
                .Take(questionPageSize)
                .ToListAsync();

            // ===============================
            // TEST CATEGORIES 
            // ===============================
            testPage = testPage < 1 ? 1 : testPage;

            var testsQuery = _context.TestCategories.OrderBy(tc => tc.CategoryId);
            int totalTests = await testsQuery.CountAsync();
            int totalTestPages = (int)Math.Ceiling((double)totalTests / testPageSize);

            if (testPage > totalTestPages && totalTestPages > 0)
                testPage = totalTestPages;

            var testsPage = await testsQuery
                .Skip((testPage - 1) * testPageSize)
                .Take(testPageSize)
                .ToListAsync();

            // ===============================
            // FEEDBACKS
            // ===============================
            const int feedbackPageSize = 10;
            feedbackPage = feedbackPage < 1 ? 1 : feedbackPage;

            var feedbackQuery = _context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.CreatedAt);

            int totalFeedbacks = await feedbackQuery.CountAsync();
            int totalFeedbackPages = (int)Math.Ceiling((double)totalFeedbacks / feedbackPageSize);

            if (feedbackPage > totalFeedbackPages && totalFeedbackPages > 0)
                feedbackPage = totalFeedbackPages;

            var feedbacksPage = await feedbackQuery
                .Skip((feedbackPage - 1) * feedbackPageSize)
                .Take(feedbackPageSize)
                .ToListAsync();

            // ===============================
            // RECENT LOGS
            // ===============================
            var recentLogs = await _context.UserActivityLogs
                .OrderByDescending(x => x.Timestamp)
                .Take(10)
                .ToListAsync();

            // ===============================
            // VIEW MODEL
            // ===============================

            var vm = new DashboardViewModel
            {
                // TESTS
                Tests = testsPage,
                CurrentTestPage = testPage,
                TestPageSize = testPageSize,
                TotalTestPages = totalTestPages,
                TotalTests = totalTests,

                // FEEDBACKS
                Feedbacks = feedbacksPage,
                CurrentFeedbackPage = feedbackPage,
                FeedbackPageSize = feedbackPageSize,
                TotalFeedbackPages = totalFeedbackPages,
                TotalFeedbacks = totalFeedbacks,

                // COUNTS
                TotalUsers = totalUsers,
                TotalQuestions = totalQuestions,
                PendingFeedbackCount = await _context.Feedbacks
            .CountAsync(f => f.Status == "Chờ Xử Lý" || f.Status == "Pending"),

                // USERS
                Users = users,
                CurrentUserPage = userPage,
                UserPageSize = userPageSize,
                TotalUserPages = totalUserPages,

                // QUESTIONS
                QuestionWithAnswers = questionList,
                CurrentQuestionPage = questionPage,
                QuestionPageSize = questionPageSize,
                TotalQuestionPages = totalQuestionPages,
                Categories = categories,
                SelectedCategory = categoryFilter,

                // LOGS
                UserActivityLogs = recentLogs
            };


            ViewBag.ActiveTab = tab;
            _logger.LogInformation("Số lượng TestCategories load được: {Count}", vm.Tests.Count);
            _logger.LogInformation("Feedbacks Count: {Count}", vm.Feedbacks.Count);
            Console.WriteLine($"Tests Count: {vm.Tests.Count}");
            Console.WriteLine($"Feedbacks Count: {vm.Feedbacks.Count}");
            return View(vm);
        }



        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Where(u => u.Role == 0) 
                .Select(u => new {
                    userId = u.UserId,
                    username = u.Username,
                    email = u.Email,
                    role = u.Role
                }).ToListAsync();
            return Json(new { users });
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Dashboard_Admin", new { tab = "users" });
        }


        [HttpGet]
        public async Task<IActionResult> GetUserTests(int userId)
        {
            try
            {
                var userTests = await _context.Tests
                    .Include(t => t.TestDetails)
                    .Where(t => t.UserId == userId)
                    .ToListAsync();

                var viewModel = new List<dynamic>();
                foreach (var test in userTests)
                {
                    var correctAnswersCount = test.TestDetails.Count(td => td.IsCorrect ?? false);
                    viewModel.Add(new
                    {
                        testId = test.TestId,
                        startTime = test.StartTime,
                        endTime = test.EndTime,
                        score = test.Score,
                        correctAnswers = correctAnswersCount
                    });
                }

                _logger.LogInformation("Lấy dữ liệu bài thi cho người dùng {UserId} thành công. Số lượng bài thi: {TestCount}", userId, userTests.Count);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu bài thi cho người dùng {UserId}", userId);
                return View("Error", "Lỗi khi tải dữ liệu. Vui lòng thử lại.");
            }
        }
        public async Task<IActionResult> Questions()
        {
            var questions = await (from q in _context.Questions
                                   join a in _context.Answers
                                       on new { q.QuestionId, q.CorrectAnswer }
                                       equals new { QuestionId = a.QuestionId, CorrectAnswer = a.OptionKey }
                                   orderby q.QuestionId
                                   select new QuestionWithAnswerViewModel
                                   {
                                       ID = q.QuestionId,
                                       QuestionText = q.QuestionText,
                                       ImageUrl = q.ImageUrl,
                                       CorrectAnswer = a.OptionText
                                   }).ToListAsync();

            return View(questions);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard_Admin", "Dashboard", new { tab = "questions" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTest(int id)
        {
            try
            {
                var testCategory = await _context.TestCategories.FindAsync(id);
                if (testCategory == null)
                {
                    _logger.LogWarning("Không tìm thấy TestCategory với ID: {CategoryId}", id);
                    return NotFound();
                }

                _context.TestCategories.Remove(testCategory);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Đã xóa TestCategory ID: {CategoryId} thành công", id);
                return RedirectToAction("Dashboard_Admin", new { tab = "tests" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa TestCategory ID: {CategoryId}", id);
                return RedirectToAction("Dashboard_Admin", new { tab = "tests" });
            }
        }

        [HttpGet]
        public IActionResult EditQuestion(int id, string tab = "questions", int questionPage = 1)
        {
            var questionEntity = _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefault(q => q.QuestionId == id);

            if (questionEntity == null)
                return NotFound();

            System.Diagnostics.Debug.WriteLine($"=== Load Question ID: {id} ===");
            System.Diagnostics.Debug.WriteLine($"QuestionText: '{questionEntity.QuestionText}'");
            System.Diagnostics.Debug.WriteLine($"CorrectAnswer: '{questionEntity.CorrectAnswer}'");
            System.Diagnostics.Debug.WriteLine($"Answers count: {questionEntity.Answers.Count}");
            foreach (var ans in questionEntity.Answers)
            {
                System.Diagnostics.Debug.WriteLine($"  {ans.OptionKey}: '{ans.OptionText}'");
            }

            var model = new EditQuestionViewModel
            {
                QuestionId = questionEntity.QuestionId,
                QuestionText = questionEntity.QuestionText ?? "",
                ImageUrl = questionEntity.ImageUrl,
                CorrectOption = questionEntity.CorrectAnswer ?? "A",
                OptionA = questionEntity.Answers.FirstOrDefault(a => a.OptionKey == "A")?.OptionText ?? "",
                OptionB = questionEntity.Answers.FirstOrDefault(a => a.OptionKey == "B")?.OptionText ?? "",
                OptionC = questionEntity.Answers.FirstOrDefault(a => a.OptionKey == "C")?.OptionText ?? "",
                OptionD = questionEntity.Answers.FirstOrDefault(a => a.OptionKey == "D")?.OptionText ?? ""
            };

            System.Diagnostics.Debug.WriteLine($"Model QuestionText: '{model.QuestionText}'");
            System.Diagnostics.Debug.WriteLine($"Model CorrectOption: '{model.CorrectOption}'");
            System.Diagnostics.Debug.WriteLine($"Model OptionA: '{model.OptionA}'");
            System.Diagnostics.Debug.WriteLine($"Model OptionB: '{model.OptionB}'");
            System.Diagnostics.Debug.WriteLine("====================================");

            ViewBag.Tab = tab;
            ViewBag.CurrentQuestionPage = questionPage;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(EditQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var reload = await _context.Questions
                    .Include(q => q.Answers)
                    .FirstOrDefaultAsync(q => q.QuestionId == model.QuestionId);
                if (reload != null)
                {
                    model.QuestionText = reload.QuestionText ?? "";
                    model.CorrectOption = reload.CorrectAnswer ?? "A";
                    model.OptionA = reload.Answers.FirstOrDefault(a => a.OptionKey == "A")?.OptionText ?? "";
                    model.OptionB = reload.Answers.FirstOrDefault(a => a.OptionKey == "B")?.OptionText ?? "";
                    model.OptionC = reload.Answers.FirstOrDefault(a => a.OptionKey == "C")?.OptionText ?? "";
                    model.OptionD = reload.Answers.FirstOrDefault(a => a.OptionKey == "D")?.OptionText ?? "";
                    model.ImageUrl = reload.ImageUrl;
                }
                return View(model);
            }

            var question = await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuestionId == model.QuestionId);

            if (question == null)
                return NotFound();

            question.QuestionText = model.QuestionText;
            question.CorrectAnswer = model.CorrectOption;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);

                question.ImageUrl = "/images/" + fileName;
            }

           
            foreach (var ans in question.Answers)
            {
                string newText = "";
                switch (ans.OptionKey)
                {
                    case "A":
                        newText = model.OptionA ?? "";
                        break;
                    case "B":
                        newText = model.OptionB ?? "";
                        break;
                    case "C":
                        newText = model.OptionC ?? "";
                        break;
                    case "D":
                        newText = model.OptionD ?? "";
                        break;
                }
                
                if (ans.OptionText != newText)
                {
                    ans.OptionText = newText;
                    _context.Entry(ans).Property(a => a.OptionText).IsModified = true;
                }
            }

            var entry = _context.Entry(question);
            if (entry.State == EntityState.Unchanged)
            {
                entry.State = EntityState.Modified;
            }

            _logger.LogInformation("Đang lưu câu hỏi ID: {QuestionId}", question.QuestionId);
            _logger.LogInformation("QuestionText: {QuestionText}, CorrectAnswer: {CorrectAnswer}", 
                question.QuestionText, question.CorrectAnswer);
            foreach (var ans in question.Answers)
            {
                _logger.LogInformation("Answer {Key}: {Text} (State: {State})", 
                    ans.OptionKey, ans.OptionText, _context.Entry(ans).State);
            }

            var savedChanges = await _context.SaveChangesAsync();
            _logger.LogInformation("Đã lưu {Count} thay đổi vào database", savedChanges);

            if (savedChanges == 0)
            {
                _logger.LogWarning("CẢNH BÁO: Không có thay đổi nào được lưu vào database!");
                _context.Entry(question).State = EntityState.Modified;
                foreach (var ans in question.Answers)
                {
                    _context.Entry(ans).State = EntityState.Modified;
                }
                savedChanges = await _context.SaveChangesAsync();
                _logger.LogInformation("Sau khi force Modified, đã lưu {Count} thay đổi", savedChanges);
            }

            return RedirectToAction("Dashboard_Admin", new { tab = "questions" });
        }
        private void UpdateAnswer(List<Answer> answers, string key, string text)
        {
            var answer = answers.FirstOrDefault(a => a.OptionKey == key);
            if (answer != null) answer.OptionText = text ?? "";
        }



        public async Task<IActionResult> Index()
        {
            var feedbacks = await _context.Feedbacks
                .Include(f => f.User) 
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();

            return View(feedbacks); 
        }

        [HttpPost]
        public async Task<IActionResult> Resolve(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return NotFound();

            if (feedback.Status == "Chờ Xử Lý")
            {
                feedback.Status = "Đã Xử Lý";
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return BadRequest("Phản hồi này đã được xử lý trước đó.");
        }


    }



}

