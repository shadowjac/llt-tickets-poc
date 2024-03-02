using LLT.PrintTickets.PoC.Domain.Abstractions;
using LLT.PrintTickets.PoC.Domain.Shared;
using LLT.PrintTickets.PoC.Domain.Tickets.Events;

namespace LLT.PrintTickets.PoC.Domain.Tickets;

public sealed class Ticket : Entity
{
    private Ticket()
    {
        
    }
    private Ticket(Guid id,
        Guid ownerId,
        MatchDate matchDate,
        Team home,
        Team visitor,
        Money? price,
        DateTime createdAt) : base(id)
    {
        OwnerId = ownerId;
        MatchDate = matchDate;
        Home = home;
        Visitor = visitor;
        Price = price;
        CreatedAt = createdAt;
    }

  

    public Guid OwnerId { get; private set; }
    public MatchDate MatchDate { get; private set; }
    public Team Home { get; private set; }
    public Team Visitor { get; private set; }
    public Money? Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? PrintedAt { get; private set; }
    public bool IsPrinted { get; set; }
    
    public static Ticket Create(Guid ownerId,
        MatchDate matchDate,
        Team home,
        Team visitor,
        Money? price,
        DateTime createdAt)
    {
        var ticket = new Ticket(Guid.NewGuid(), ownerId, matchDate, home, visitor, price, createdAt);
        
        ticket.RaiseDomainEvent(new TicketCreatedDomainEvent(ticket.Id));
        ticket.CreatedAt = createdAt;

        return ticket;
    }
}