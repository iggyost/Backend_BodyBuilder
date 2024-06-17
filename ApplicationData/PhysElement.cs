using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class PhysElement
{
    public int PhysElementId { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan RequiredTime { get; set; }

    public string CoverImage { get; set; } = null!;

    public virtual ICollection<TrainingPhysElement> TrainingPhysElements { get; set; } = new List<TrainingPhysElement>();
}
