using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LLT.PrintTickets.PoC.Api.Controllers;

public class TicketsController : BaseController
{
    public TicketsController(ISender sender) : base(sender)
    {
    }
}