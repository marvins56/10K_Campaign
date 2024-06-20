using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetCampaignQuery : IRequest<CampaignDto>
{
    public DefaultIdType CampaignId { get; set; }

    public GetCampaignQuery(DefaultIdType campaignId)
    {
        CampaignId = campaignId;
    }
}
