using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetCampaignByIdQuery : IRequest<CampaignDto>
{
    public Guid CampaignId { get; set; }

    public GetCampaignByIdQuery(Guid campaignId)
    {
        CampaignId = campaignId;
    }
}