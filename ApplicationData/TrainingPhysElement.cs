using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class TrainingPhysElement
{
    public int TrainingElementId { get; set; }

    public int TrainingId { get; set; }

    public int PhysElementId { get; set; }

    public virtual PhysElement PhysElement { get; set; } = null!;

    public virtual Training Training { get; set; } = null!;
}
