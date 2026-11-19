using System;
using System.Collections.Generic;

namespace ShoeStore.Models;

public partial class Production
{
    public int ProductionId { get; set; }

    public string ProductionName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
