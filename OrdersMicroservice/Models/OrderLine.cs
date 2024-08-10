namespace OrdersMicroservice.Models;

public sealed record OrderLine
{
    public int OrderLineId { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}