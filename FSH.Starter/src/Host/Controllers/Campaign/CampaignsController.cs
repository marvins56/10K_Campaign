using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;

namespace FSH.Starter.Host.Controllers.Campaign;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CampaignsController : VersionedApiController
{
    [HttpGet("{id}")]
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
    public async Task<ActionResult<int>> Create(CreateCampaignRequest request)
    {
        //add try and catch block
        try
        {
            return Ok(await Mediator.Send(new CreateCampaignCommand(request)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateCampaignRequest request)
    {
        try
        {
            if (id != request.CampaignId)
                return BadRequest();

            await Mediator.Send(new UpdateCampaignCommand(request));
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        
        }

    
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCampaignsQuery query)
    {
        var campaigns = await Mediator.Send(query);
        return Ok(campaigns);
    }
}