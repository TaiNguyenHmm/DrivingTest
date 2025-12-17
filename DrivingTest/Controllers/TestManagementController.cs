using DrivingTest.Models;
using DrivingTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TestManagementController : Controller
{
    private readonly DrivingTestContext _context;

    public TestManagementController(DrivingTestContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> PracticeTest()
    {
        var questions = await _context.Questions
            .Include(q => q.Answers)
            .OrderBy(q => Guid.NewGuid())
            .Take(30)
            .ToListAsync();

        return View(questions);
    }
    public IActionResult Index(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return NotFound("Không tìm thấy mục luyện tập.");
        }

        var questions = _context.Questions
                                .Include(q => q.Answers)
                                .Where(q => q.Category == category)
                                .OrderBy(q => Guid.NewGuid())
                                            .Take(30) 
                                .ToList();

        if (questions.Count == 0)
        {
            return NotFound($"Không có câu hỏi nào trong mục '{category}'.");
        }

        return View(questions);
    }


    public IActionResult SelectTest()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> MockTest(string category)
    {
        int categoryId = category switch
        {
            "B1-B11" => 1,
            "B2" => 2,
            "C" => 3,
            "D-E-F" => 4,
            _ => throw new ArgumentException("Hạng bằng không hợp lệ")
        };

        var config = await _context.TestCategories.FindAsync(categoryId);
        if (config == null) return NotFound();

        var questions = await _context.Questions
            .Include(q => q.Answers)
            .OrderBy(q => Guid.NewGuid())
            .Take(config.QuestionCount)
            .ToListAsync();

        var vm = new MockTestViewModel
        {
            Category = category,
            Questions = questions,
            TestDurationInMinutes = config.DurationMinutes,
            PassingScore = config.PassingScore
        };

        return View("MockTest", vm);
    }


}
