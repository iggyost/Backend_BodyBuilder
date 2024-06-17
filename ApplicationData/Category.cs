using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
