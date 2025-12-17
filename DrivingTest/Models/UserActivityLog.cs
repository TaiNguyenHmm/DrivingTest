using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class UserActivityLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string ActionType { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public string? Details { get; set; }

    public virtual User? User { get; set; }
}
