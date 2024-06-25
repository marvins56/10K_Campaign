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

    [HttpGet("{id}")]
    public async Task<ActionResult<FundraiserDto>> GetFundraiserById(Guid id)
    {
        var fundraiser = await _mediator.Send(new GetFundraiserByIdQuery(id));
        return Ok(fundraiser);
    }

    [HttpGet]
    public async Task<ActionResult<List<FundraiserDto>>> GetAll()
    {
        var query = new GetAllFundraisersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateFundraiserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { message = "Donor Created and attached to respective account successfully"});
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateFundraiserCommand command)
    {
        if (id != command.FundraiserId)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return Ok(new { message = "Donor Updated successfully" });
    }

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> Delete(Guid id)
    //{
    //    await _mediator.Send(new DeleteFundraiserCommand { FundraiserId = id });
    //    return NoContent();
    //}
}
