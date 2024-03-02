using LLT.PrintTickets.PoC.Application.Buyers.GetBuyer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LLT.PrintTickets.PoC.Api.Controllers.Buyers;

public class BuyersController : BaseController
{
    public BuyersController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetBuyerQuery(id);

        var buyer = await _sender.Send(query, cancellationToken);

        return Ok(buyer.Value);
    }
}