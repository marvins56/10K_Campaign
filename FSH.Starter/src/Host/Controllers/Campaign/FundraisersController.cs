using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using MediatR;

namespace FSH.Starter.Host.Controllers.Campaign;
[Route("api/[controller]")]
[ApiController]
public class FundraisersController : ControllerBase
{
    private readonly IMediator _mediator;

    public FundraisersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<FundraiserDto>>> GetAll([FromQuery] string filter, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        var query = new GetAllFundraisersQuery { Filter = filter, Page = page, PageSize = pageSize };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateFundraiserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateFundraiserCommand command)
    {
        if (id != command.FundraiserId)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> Delete(Guid id)
    //{
    //    await _mediator.Send(new DeleteFundraiserCommand { FundraiserId = id });
    //    return NoContent();
    //}
}
