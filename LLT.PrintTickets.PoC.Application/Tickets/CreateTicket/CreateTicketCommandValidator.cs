using Application.Abstractions.Clock;
using FluentValidation;

namespace LLT.PrintTickets.PoC.Application.Tickets.CreateTicket;

internal class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator(IDateTimeProvider dateTimeProvider)
    {
        RuleFor(t => t.Home).NotEmpty();
        RuleFor(t => t.Visitor)
            .NotEmpty()
            .NotEqual(t => t.Home);
        RuleFor(t => t.Price)
            .GreaterThan(0);
        RuleFor(t => t.MatchDate)
            .GreaterThan(DateOnly.FromDateTime(dateTimeProvider.UtcNow));
    }
}