using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetAccountByIdQuery : IRequest<AccountDto>
{
    public DefaultIdType AccountId { get; set; }
}

public class GetCampaignByIdWithAccountsQuery : IRequest<CampaignDto>
{
    public Guid CampaignId { get; }

    public GetCampaignByIdWithAccountsQuery(Guid campaignId)
    {
        CampaignId = campaignId;
    }
}

