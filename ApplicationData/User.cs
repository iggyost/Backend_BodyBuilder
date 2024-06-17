using System;
using System.Collections.Generic;

namespace Backend_BodyBuilder.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<DailyStatisticHealth> DailyStatisticHealths { get; set; } = new List<DailyStatisticHealth>();
}
