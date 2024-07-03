using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FSH.Starter.Host.Controllers.Campaign;
[ApiController]
[Route("api/[controller]")]
public class DonationsController : VersionedApiController
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Donations)]
    [OpenApiOperation("Create Transaction Donation ", "")]
    public async Task<IActionResult> Create(CreateDonationCommand command)
    {
        var donationId = await _mediator.Send(command);
        return Ok(new { message = "Transaction successfully recieved" });
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Donations)]
    [OpenApiOperation("Get all Donation Transaction ", "")]
    public async Task<ActionResult<List<DonationDto>>> GetAll()
    {
        return await _mediator.Send(new GetAllDonationsQuery());
    }

    [HttpGet("{id:guid}")]

    [MustHavePermission(FSHAction.View, FSHResource.Donations)]
    [OpenApiOperation("Get all Donation Transaction ", "")]
    public async Task<ActionResult<DonationDto>> GetById(Guid id)
    {
        return await _mediator.Send(new GetDonationByIdQuery { DonationId = id });
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Donations)]
    [OpenApiOperation("Update Donation Transaction ", "")]
    public async Task<IActionResult> Update(Guid id, UpdateDonationCommand command)
    {
        if (id != command.DonationId)
        {
            return BadRequest("ID mismatch.");
        }

        await _mediator.Send(command);
        return Ok(new { message = "Transaction successfully updated" });
    }
}
