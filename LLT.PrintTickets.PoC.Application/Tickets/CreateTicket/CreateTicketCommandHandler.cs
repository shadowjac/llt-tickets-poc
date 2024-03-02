using Application.Abstractions.Clock;
using Application.Abstractions.Messaging;
using LLT.PrintTickets.PoC.Application.Exceptions;
using LLT.PrintTickets.PoC.Domain.Abstractions;
using LLT.PrintTickets.PoC.Domain.Buyers;
using LLT.PrintTickets.PoC.Domain.Buyers.Repositories;
using LLT.PrintTickets.PoC.Domain.Shared;
using LLT.PrintTickets.PoC.Domain.Tickets;
using LLT.PrintTickets.PoC.Domain.Tickets.Repositories;

namespace LLT.PrintTickets.PoC.Application.Tickets.CreateTicket;

public sealed class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IBuyerRepository _buyerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(IDateTimeProvider dateTimeProvider, IBuyerRepository buyerRepository,
        IUnitOfWork unitOfWork, ITicketRepository ticketRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _buyerRepository = buyerRepository;
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<Result<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var buyer = await _buyerRepository.GetByIdAsync(request.OwnerId, cancellationToken);
        if (buyer is null)
        {
            return Result.Failure<Guid>(BuyerErrors.NotFound);
        }

        var matchDate = MatchDate.Create(request.MatchDate, request.MatchTime);

        try
        {
            var ticket = Ticket.Create(request.OwnerId,
                matchDate,
                new Team(request.Home),
                new Team(request.Visitor),
                new Money(request.Price,
                    Currency.Dollar),
                _dateTimeProvider.UtcNow);

            await _ticketRepository.AddAsync(ticket, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ticket.Id;
        }
        catch (Exception e)
        {
            return Result.Failure<Guid>(TicketsError.GeneralError(e.Message));
        }
    }
}