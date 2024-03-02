namespace LLT.PrintTickets.PoC.Application.Buyers.GetBuyer;

public sealed class BuyerResponse
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
}