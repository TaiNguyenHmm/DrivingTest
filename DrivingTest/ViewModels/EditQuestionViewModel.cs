using System.ComponentModel.DataAnnotations;

namespace DrivingTest.ViewModels  
{
    public class EditQuestionViewModel
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung câu hỏi")]
        public string QuestionText { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng chọn đáp án đúng")]
        public string CorrectOption { get; set; } = "A";

        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung đáp án A")]
        public string OptionA { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập nội dung đáp án B")]
        public string OptionB { get; set; } = "";

        public string OptionC { get; set; } = "";
        public string OptionD { get; set; } = "";
    }
}