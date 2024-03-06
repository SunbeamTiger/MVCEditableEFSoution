using System;
using System.Collections.Generic;

namespace DBProject.Models;

public partial class CustomerOrder
{
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public decimal? TotalAmount { get; set; }
    public string? City { get; set; }
    public DateTime OrderDate { get; set; }
}
