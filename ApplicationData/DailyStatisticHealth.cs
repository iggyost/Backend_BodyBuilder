using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class DailyStatisticHealth
{
    public int StatisticHealthId { get; set; }

    public int UserId { get; set; }

    public int Calories { get; set; }

    public TimeSpan SpentTime { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; } = null!;
}
