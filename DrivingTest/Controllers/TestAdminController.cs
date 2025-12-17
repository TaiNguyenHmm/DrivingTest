using DrivingTest.Models;
using DrivingTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrivingTest.Controllers
{
    public class TestAdminController : Controller
    {
        private readonly DrivingTestContext _context;
        private readonly ILogger<TestAdminController> _logger;

        public TestAdminController(DrivingTestContext context, ILogger<TestAdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestViewModel model)
        {
            if (model == null)
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });

            // Basic validation
            if (string.IsNullOrWhiteSpace(model.TestName))
                return BadRequest(new { success = false, message = "Tên bài thi là bắt buộc." });

            if (model.Questions == null || !model.Questions.Any())
                return BadRequest(new { success = false, message = "Phải có ít nhất một câu hỏi." });

            foreach (var q in model.Questions)
            {
                if (string.IsNullOrWhiteSpace(q.QuestionText))
                    return BadRequest(new { success = false, message = "Tất cả câu hỏi phải có nội dung." });

                if (q.Answers == null || q.Answers.Count < 2)
                    return BadRequest(new { success = false, message = "Mỗi câu hỏi phải có ít nhất 2 đáp án." });

                if (string.IsNullOrWhiteSpace(q.CorrectAnswer) || !q.Answers.Any(a => a.OptionKey == q.CorrectAnswer))
                    return BadRequest(new { success = false, message = "Mỗi câu hỏi phải có đáp án đúng hợp lệ." });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Create TestCategory (we store parameters there). There's no name property on TestCategory model,
                // so we persist counts/duration/passing score and return its id.
                var category = new TestCategory
                {
                    QuestionCount = model.QuestionCount,
                    DurationMinutes = model.DurationMinutes,
                    PassingScore = model.PassingScore
                };

                _context.TestCategories.Add(category);
                await _context.SaveChangesAsync();

                // Create questions and answers
                foreach (var q in model.Questions)
                {
                    var question = new Question
                    {
                        QuestionText = q.QuestionText ?? string.Empty,
                        ImageUrl = q.ImageUrl,
                        Category = q.Category,
                        CorrectAnswer = q.CorrectAnswer ?? ""
                    };

                    _context.Questions.Add(question);
                    await _context.SaveChangesAsync(); // ensure QuestionId

                    foreach (var a in q.Answers)
                    {
                        var answer = new Answer
                        {
                            QuestionId = question.QuestionId,
                            OptionKey = a.OptionKey,
                            OptionText = a.OptionText ?? string.Empty
                        };
                        _context.Answers.Add(answer);
                    }
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                _logger.LogInformation("Tạo bài thi thành công. TestCategoryId={CategoryId}", category.CategoryId);
                return Json(new { success = true, categoryId = category.CategoryId });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Lỗi khi tạo bài thi");
                return StatusCode(500, new { success = false, message = "Lỗi khi lưu dữ liệu." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { success = false, message = "No file provided." });
            }

            try
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var url = "/images/" + fileName;
                _logger.LogInformation("Image uploaded: {Url}", url);
                return Json(new { success = true, imageUrl = url });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading image");
                return StatusCode(500, new { success = false, message = "Lỗi khi upload ảnh." });
            }
        }

        // New endpoint: get test category by id
        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var cat = await _context.TestCategories.FindAsync(id);
            if (cat == null) return NotFound(new { success = false, message = "Không tìm thấy bài thi." });
            return Json(new { success = true, data = new { cat.CategoryId, cat.QuestionCount, cat.DurationMinutes, cat.PassingScore } });
        }

        // New endpoint: update test category
        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] TestCategoryDto dto)
        {
            if (dto == null) return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
            var cat = await _context.TestCategories.FindAsync(dto.CategoryId);
            if (cat == null) return NotFound(new { success = false, message = "Không tìm thấy bài thi." });

            cat.QuestionCount = dto.QuestionCount;
            cat.DurationMinutes = dto.DurationMinutes;
            cat.PassingScore = dto.PassingScore;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated TestCategory {Id}", dto.CategoryId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating TestCategory {Id}", dto.CategoryId);
                return StatusCode(500, new { success = false, message = "Lỗi khi cập nhật." });
            }
        }
    }
}
