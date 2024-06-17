using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class Road
{
    public int RoadId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
