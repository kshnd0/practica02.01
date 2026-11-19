using System;
using System.Collections.Generic;

namespace ShoeStore.Models;

public partial class StockItem
{
    public int StockItemsId { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int StockQuantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
