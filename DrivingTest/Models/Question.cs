using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? Category { get; set; }

    public string CorrectAnswer { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<TestDetail> TestDetails { get; set; } = new List<TestDetail>();
}
