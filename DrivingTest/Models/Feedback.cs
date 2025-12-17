using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingTest.Models;

[Table("Feedback")]  
public  class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public string? Title { get; set; }

    public virtual User? User { get; set; }
}
