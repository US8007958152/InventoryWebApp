using System;
using System.Collections.Generic;

namespace InventoryWebApp.Models;

public partial class Product
{
    public int ProductNo { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? CostPrice { get; set; }

    public int Qty { get; set; }

    public decimal? SalesPrice { get; set; }
}
