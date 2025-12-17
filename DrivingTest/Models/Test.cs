using System;
using System.Collections.Generic;

namespace DrivingTest.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int? Score { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual TestCategory Category { get; set; } = null!;

    public virtual ICollection<TestDetail> TestDetails { get; set; } = new List<TestDetail>();

    public virtual User User { get; set; } = null!;
}
