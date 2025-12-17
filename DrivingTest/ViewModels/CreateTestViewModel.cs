
namespace DrivingTest.ViewModels
{
    public class CreateTestViewModel
    {
        public string? TestName { get; set; }
        public int QuestionCount { get; set; }
        public int DurationMinutes { get; set; }
        public int PassingScore { get; set; }
        public string? Category { get; set; }
        public List<CreateQuestionViewModel> Questions { get; set; } = new List<CreateQuestionViewModel>();
    }

    public class CreateQuestionViewModel
    {
        public string? QuestionText { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<CreateAnswerViewModel> Answers { get; set; } = new List<CreateAnswerViewModel>();
    }

    public class CreateAnswerViewModel
    {
        public string OptionKey { get; set; } = null!;
        public string? OptionText { get; set; }
    }
}
