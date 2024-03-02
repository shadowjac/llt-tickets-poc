using LLT.PrintTickets.PoC.Domain.Buyers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Configurations;

internal sealed class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.ToTable("buyers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .HasConversion(name => name!.Value,
                name => new Name(name));

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .HasConversion(name => name!.Value,
                name => new LastName(name));

        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .HasConversion(name => name!.Value,
                name => new Email(name));

        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}