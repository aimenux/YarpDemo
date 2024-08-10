using System;
using System.Collections.Generic;

namespace OrdersMicroservice.Models;

public sealed record Order
{
    public int OrderId { get; init; }
    public int CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public ICollection<OrderLine> OrderLines { get; init; }
}