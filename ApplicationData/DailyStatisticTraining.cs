using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class DailyStatisticTraining
{
    public int StatisticTrainingId { get; set; }

    public int UserId { get; set; }

    public int TrainingId { get; set; }

    public bool Completed { get; set; }

    public DateTime Date { get; set; }

    public virtual Training Training { get; set; } = null!;
}
