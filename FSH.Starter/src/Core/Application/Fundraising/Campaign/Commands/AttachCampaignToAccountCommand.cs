using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class AttachCampaignToAccountCommand : IRequest
{
    public Guid CampaignId { get; set; }
    public Guid AccountId { get; set; }

    public AttachCampaignToAccountCommand(Guid campaignId, Guid accountId)
    {
        CampaignId = campaignId;
        AccountId = accountId;
    }
}
