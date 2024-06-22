using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetAllCampaignsQuery : IRequest<List<CampaignDto>>
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? Filter { get; set; }
}
