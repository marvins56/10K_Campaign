using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using Microsoft.AspNetCore.Mvc;

namespace FSH.Starter.Host.Controllers.Campaign;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CampaignsController : VersionedApiController
{
    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Campaigns)]
    [OpenApiOperation("Get Campaigns details.", "")]
    public async Task<ActionResult<CampaignDto>> Get(Guid id)
    {
        try
        {
            return Ok(await Mediator.Send(new GetCampaignByIdQuery(id)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Campaigns)]
    [OpenApiOperation("Create Campaigns details.", "")]
    public async Task<ActionResult<int>> Create(CreateCampaignRequest request)
    {
        //add try and catch block
        try
        {
            await Mediator.Send(new CreateCampaignCommand(request));
            return Ok(new { Message = "Campaign Created Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Campaigns)]
    [OpenApiOperation("Update Campaigns details.", "")]
    public async Task<ActionResult> Update(Guid id, UpdateCampaignRequest request)
    {
        try
        {
            if (id != request.CampaignId)
                return BadRequest();

            await Mediator.Send(new UpdateCampaignCommand(request));
            return Ok(new { Message = "Campaign Updated Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Campaigns)]
    [OpenApiOperation("View Campaigns details.", "")]
    public async Task<IActionResult> GetAll()
    {
        var campaigns = await Mediator.Send(new GetAllCampaignsQuery());
        return Ok(campaigns);
    }

    [HttpPost("{campaignId}/attach-account/{accountId}")]
    public async Task<ActionResult> AttachCampaignToAccount(Guid campaignId, Guid accountId)
    {
        try
        {
            await Mediator.Send(new AttachCampaignToAccountCommand(campaignId, accountId));
            return Ok(new { Message = "Campaign attached to account successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //
    // Endpoint to get a CampaignStudent by composite key (CampaignId and StudentId)
    [HttpGet("{campaignId}/students/{studentId}")]
    public async Task<ActionResult<CampaignStudentDto>> GetCampaignStudent(Guid campaignId, Guid studentId)
    {
        try
        {
            return Ok(await Mediator.Send(new GetCampaignStudentByIdQuery(campaignId, studentId)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint to create a new CampaignStudent
    [HttpPost("students")]
    public async Task<ActionResult<Guid>> CreateCampaignStudent(CreateCampaignStudentCommand command)
    {
        try
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint to update an existing CampaignStudent
    [HttpPut("{campaignId}/students/{studentId}")]
    public async Task<ActionResult> UpdateCampaignStudent(Guid campaignId, Guid studentId, UpdateCampaignStudentCommand command)
    {
        try
        {
            if (campaignId != command.CampaignId || studentId != command.StudentId)
                return BadRequest("CampaignId and StudentId do not match the request.");

            await Mediator.Send(command);
            return Ok(new { Message = "CampaignStudent Updated Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetAllCampaignStudents()
    {
        try
        {
            var campaignStudents = await Mediator.Send(new GetAllCampaignStudentsQuery());
            return Ok(campaignStudents);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
