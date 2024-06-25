using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetFundraiserByIdQuery : IRequest<FundraiserDto>
{
    public Guid FundraiserId { get; set; }

    public GetFundraiserByIdQuery(Guid fundraiserId)
    {
        FundraiserId = fundraiserId;
    }
}

