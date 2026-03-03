using System;
using System.Collections.Generic;

namespace EKART.Models;

public partial class Territory
{
    public int TerritoryId { get; set; }

    public string? TerritoryDescription { get; set; }

    public int? RegionId { get; set; }

    public virtual Region? Region { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
