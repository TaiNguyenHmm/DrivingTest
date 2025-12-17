using DrivingTest.Models;

namespace DrivingTest.ViewModels
{
    using System.Collections.Generic;

    public class MockTestViewModel
    {
        public string Category { get; set; }           
        public List<Question> Questions { get; set; }  
        public int TestDurationInMinutes { get; set; } 
        public int PassingScore { get; set; }          
    }
}
