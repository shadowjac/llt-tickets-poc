using LLT.PrintTickets.PoC.Domain.Abstractions;

namespace LLT.PrintTickets.PoC.Domain.Buyers;

public sealed class Buyer : Entity
{
    public Buyer()
    {
            
    }
    
    public Name? Name { get; private set; }
    public LastName? LastName { get; private set; }
    public Email? Email { get; private set; }
}