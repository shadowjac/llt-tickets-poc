namespace LLT.PrintTickets.PoC.Domain.Tickets;

public sealed record MatchDate
{
    private MatchDate(DateOnly Day,
        TimeOnly Time)
    {
        this.Day = Day;
        this.Time = Time;
    }


    public DateOnly Day { get; init; }
    public TimeOnly Time { get; init; }

    public static MatchDate Create(DateOnly day, TimeOnly time)
    {
        return new MatchDate(day, time);
    }
}