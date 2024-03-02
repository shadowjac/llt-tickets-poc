using Application.Abstractions.Clock;
using Application.Abstractions.Data;
using Dapper;
using LLT.PrintTickets.PoC.Domain.Abstractions;
using LLT.PrintTickets.PoC.Domain.Buyers.Repositories;
using LLT.PrintTickets.PoC.Domain.Tickets.Repositories;
using LLT.PrintTickets.PoC.Infrastructure.Persistence.Data;
using LLT.PrintTickets.PoC.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new ArgumentNullException(nameof(configuration), "Connection string not found");


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped<ITicketRepository, TicketsRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

        return services;
    }
}