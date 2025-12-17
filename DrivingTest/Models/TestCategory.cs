using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class TestCategory
{
    public int CategoryId { get; set; }

    public int QuestionCount { get; set; }

    public int DurationMinutes { get; set; }

    public int PassingScore { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
