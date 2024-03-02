using Application.Abstractions.Data;
using Dapper;
using LLT.PrintTickets.PoC.Application.Abstractions.Messaging;
using LLT.PrintTickets.PoC.Domain.Abstractions;

namespace LLT.PrintTickets.PoC.Application.Buyers.GetBuyer;

public sealed class GetBuyerQueryHandler : IQueryHandler<GetBuyerQuery, BuyerResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBuyerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<BuyerResponse>> Handle(GetBuyerQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        const string sql = """
                            SELECT b.id as Id,
                                   b.name as Name,
                                   b.last_name as LastName,
                                   b.email as Email
                           FROM buyers b
                           WHERE b.id = @BuyerId
                           """;

        var buyer = await connection.QuerySingleOrDefaultAsync<BuyerResponse>(
            sql,
            new { request.BuyerId });
        return buyer!;
    }
}