
using DrivingTest.Models;

namespace DrivingTest.ViewModels
{
    public class DashboardViewModel
    {
        // ===============================
        // TESTS
        public List<TestCategory> Tests { get; set; } = new List<TestCategory>();
        public int CurrentTestPage { get; set; }
        public int TestPageSize { get; set; }
        public int TotalTestPages { get; set; }
        public int TotalTests { get; set; }

        // ===============================
        // FEEDBACKS
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public int CurrentFeedbackPage { get; set; }
        public int FeedbackPageSize { get; set; }
        public int TotalFeedbackPages { get; set; }
        public int TotalFeedbacks { get; set; }

      
        public int TotalUsers { get; set; }
        public int TotalQuestions { get; set; }
        public int PendingFeedbackCount { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int CurrentUserPage { get; set; } = 1;
        public int UserPageSize { get; set; } = 10;
        public int TotalUserPages { get; set; }
        public List<QuestionWithAnswerViewModel> QuestionWithAnswers { get; set; } = new List<QuestionWithAnswerViewModel>();
        public int CurrentQuestionPage { get; set; } = 1;
        public int QuestionPageSize { get; set; } = 10;
        public int TotalQuestionPages { get; set; }
        
        // ===============================
        // CATEGORIES FOR FILTER
        public List<string> Categories { get; set; } = new List<string>();
        public string SelectedCategory { get; set; } = "";
        
        public List<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();
    }

}