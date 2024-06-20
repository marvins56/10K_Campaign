using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using Microsoft.AspNetCore.Mvc;

namespace FSH.Starter.Host.Controllers.Campaign;
[ApiController]
[Route("api/[controller]")]
public class DonationStudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationStudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDonationStudentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<DonationStudentDto>>> GetAll()
    {
        return await _mediator.Send(new GetAllDonationStudentsQuery());
    }

    [HttpGet("{donationId}/{studentId}")]
    public async Task<ActionResult<DonationStudentDto>> GetById(Guid donationId, Guid studentId)
    {
        return await _mediator.Send(new GetDonationStudentByIdQuery { DonationId = donationId, StudentId = studentId });
    }

    [HttpPut("{donationId}/{studentId}")]
    public async Task<IActionResult> Update(Guid donationId, Guid studentId, UpdateDonationStudentCommand command)
    {
        if (donationId != command.DonationId || studentId != command.StudentId)
        {
            return BadRequest("ID mismatch.");
        }

        await _mediator.Send(command);
        return NoContent();
    }
}