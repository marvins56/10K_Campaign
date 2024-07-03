using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using MediatR;

namespace FSH.Starter.Host.Controllers.Campaign;
[Route("api/[controller]")]
[ApiController]
public class FundraisersController : VersionedApiController
{
    private readonly IMediator _mediator;

    public FundraisersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Fundraiser)]
    [OpenApiOperation("Get Fundraisers ", "")]
    public async Task<ActionResult<FundraiserDto>> GetFundraiserById(Guid id)
    {
        var fundraiser = await _mediator.Send(new GetFundraiserByIdQuery(id));
        return Ok(fundraiser);
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Fundraiser)]
    [OpenApiOperation("Get all Fundraisers ", "")]
    public async Task<ActionResult<List<FundraiserDto>>> GetAll()
    {
        var query = new GetAllFundraisersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Fundraiser)]

    [OpenApiOperation("Create Fundraisers ", "")]
    public async Task<ActionResult<Guid>> Create(CreateFundraiserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { message = "Donor Created and attached to respective account successfully" });
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Fundraiser)]
    [OpenApiOperation("Update Fundraisers ")]
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
