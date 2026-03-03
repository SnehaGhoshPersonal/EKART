using System;
using System.Collections.Generic;

namespace EKART.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateOnly? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public string? ShipVia { get; set; }

    public string? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper? ShipNameNavigation { get; set; }
}
