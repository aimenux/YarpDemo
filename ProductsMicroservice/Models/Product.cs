namespace ProductsMicroservice.Models;

public sealed record Product
{
    public int ProductId { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
}