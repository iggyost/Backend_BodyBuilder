using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class ExercisesView
{
    public int TrainingElementId { get; set; }

    public int TrainingId { get; set; }

    public int PhysElementId { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan RequiredTime { get; set; }

    public string CoverImage { get; set; } = null!;
}
