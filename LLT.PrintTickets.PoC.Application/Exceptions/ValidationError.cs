namespace LLT.PrintTickets.PoC.Application.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);