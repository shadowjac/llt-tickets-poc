using System.Data;
using Application.Abstractions.Data;
using Npgsql;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        
        return connection;
    }
}