using LLT.PrintTickets.PoC.Domain.Buyers;
using LLT.PrintTickets.PoC.Domain.Shared;
using LLT.PrintTickets.PoC.Domain.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Configurations;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.MatchDate,
            pb =>
            {
                pb.Property(x => x.Day)
                    .HasColumnName("match_day");
                
                pb.Property(x => x.Time)
                    .HasColumnName("match_time");
            });

        builder.Property(x => x.Home)
            .HasColumnName("home")
            .HasMaxLength(100)
            .HasConversion(home => home.Value,
                home => new Team(home));

        builder.Property(x => x.Visitor)
            .HasColumnName("visitor")
            .HasMaxLength(100)
            .HasConversion(visitor => visitor.Value,
                visitor => new Team(visitor));

        builder.OwnsOne(x => x.Price, pb =>
        {
            pb.Property(x => x.Currency)
                .HasConversion(currency => currency.Code,
                    code => Currency.From(code));
        });
        
        builder.HasOne<Buyer>()
            .WithMany()
            .HasForeignKey(x => x.OwnerId);
    }
}