using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetCampaignStudentByIdQuery : IRequest<CampaignStudentDto>
{
    public DefaultIdType Id { get; set; }

    public GetCampaignStudentByIdQuery(DefaultIdType id)
    {
        Id = id;
    }
}