using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public string OptionKey { get; set; } = null!;

    public string OptionText { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
