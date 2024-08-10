namespace CustomersMicroservice.Models;

public sealed record Customer
{
    public int CustomerId { get; init; }
    public string FullName { get; init; }
    public int Age { get; init; }
}