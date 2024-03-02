using System.Data;
using Dapper;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Data;

internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value;
    }

    public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);
}