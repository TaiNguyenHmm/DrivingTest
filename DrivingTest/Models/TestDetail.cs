using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class TestDetail
{
    public int TestDetailId { get; set; }

    public int TestId { get; set; }

    public int QuestionId { get; set; }

    public string? SelectedAnswer { get; set; }

    public bool? IsCorrect { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;
}
