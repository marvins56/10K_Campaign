using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, CampaignDto>
{
    private readonly IApplicationDbContext _context;

    public GetCampaignQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CampaignDto> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
    {
        var campaign = await _context.Campaigns.FindAsync(new object[] { request.CampaignId }, cancellationToken);

        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        return new CampaignDto
        {
            CampaignId = campaign.CampaignId,
            CampaignName = campaign.CampaignName,
            Description = campaign.Description,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate
        };
    }
}
