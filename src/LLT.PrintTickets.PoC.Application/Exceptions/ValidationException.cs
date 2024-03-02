namespace LLT.PrintTickets.PoC.Application.Exceptions;

public class ValidationException(IEnumerable<ValidationError> errors) : Exception
{
    public IEnumerable<ValidationError> Errors { get; } = errors;
}