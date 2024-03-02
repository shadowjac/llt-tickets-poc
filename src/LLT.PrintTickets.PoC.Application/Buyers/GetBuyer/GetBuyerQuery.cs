using LLT.PrintTickets.PoC.Application.Abstractions.Messaging;

namespace LLT.PrintTickets.PoC.Application.Buyers.GetBuyer;

public sealed record GetBuyerQuery(Guid BuyerId) : IQuery<BuyerResponse>;