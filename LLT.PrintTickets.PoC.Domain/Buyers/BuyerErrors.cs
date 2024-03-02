using LLT.PrintTickets.PoC.Domain.Abstractions;

namespace LLT.PrintTickets.PoC.Domain.Buyers;

public static class BuyerErrors
{
    public static Error NotFound => new Error("Buyer.NotFound", "Buyer not found");
}