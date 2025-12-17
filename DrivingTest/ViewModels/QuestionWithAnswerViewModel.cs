
namespace DrivingTest.ViewModels
{
    public class QuestionWithAnswerViewModel
    {
        public int ID { get; set; }                
        public string QuestionText { get; set; }   
        public string CorrectAnswer { get; set; }  
        public string? ImageUrl { get; set; }     
        public IFormFile? ImageFile { get; set; }  
        public string? Category { get; set; }      
    }
}
