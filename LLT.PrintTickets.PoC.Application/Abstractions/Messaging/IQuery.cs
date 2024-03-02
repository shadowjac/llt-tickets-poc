using LLT.PrintTickets.PoC.Domain.Abstractions;
using MediatR;

namespace LLT.PrintTickets.PoC.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}