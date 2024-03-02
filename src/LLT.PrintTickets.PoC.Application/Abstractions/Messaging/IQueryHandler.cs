using LLT.PrintTickets.PoC.Domain.Abstractions;
using MediatR;

namespace LLT.PrintTickets.PoC.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}