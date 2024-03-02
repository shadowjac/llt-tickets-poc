using Application.Abstractions.Data;
using Bogus;
using Dapper;

namespace LLT.PrintTickets.PoC.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();
        var buyer = new
        {
            Id = Guid.NewGuid(),
            Name = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Internet.Email(),
        };

        var sql = """
                    INSERT INTO public.buyers (id, name, last_name, email)
                    VALUES (@Id, @Name, @LastName, @Email);
                  """;

        connection.Execute(sql, buyer);
    }
}