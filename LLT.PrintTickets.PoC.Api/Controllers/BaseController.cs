using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LLT.PrintTickets.PoC.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly ISender _sender;

    protected BaseController(ISender sender)
    {
        _sender = sender;
    }
}