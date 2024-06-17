using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class Training
{
    public int TrainingId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TimeSpan TrainingTime { get; set; }

    public int Calories { get; set; }

    public int CategoryId { get; set; }

    public string CoverImage { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DailyStatisticTraining> DailyStatisticTrainings { get; set; } = new List<DailyStatisticTraining>();

    public virtual ICollection<TrainingPhysElement> TrainingPhysElements { get; set; } = new List<TrainingPhysElement>();
}
