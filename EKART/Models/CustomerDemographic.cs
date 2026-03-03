using System;
using System.Collections.Generic;

namespace EKART.Models;

public partial class CustomerDemographic
{
    public int CustomerTypeId { get; set; }

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
