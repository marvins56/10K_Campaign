using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class GetCampaignQuery : IRequest<CampaignDto>
{
    public Guid CampaignId { get; set; }

    public GetCampaignQuery(Guid campaignId)
    {
        CampaignId = campaignId;
    }
}
