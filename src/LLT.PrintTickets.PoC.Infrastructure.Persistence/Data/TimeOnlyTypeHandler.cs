using System.Data;
using Dapper;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Data;

internal sealed class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly value)
    {
        parameter.DbType = DbType.Time;
        parameter.Value = value;
    }

    public override TimeOnly Parse(object value) => TimeOnly.FromDateTime((DateTime)value);
}