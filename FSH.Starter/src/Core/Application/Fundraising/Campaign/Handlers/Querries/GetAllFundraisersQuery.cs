using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers.Querries;
public class GetAllFundraisersQuery : IRequest<List<FundraiserDto>>
{
    public string Filter { get; set; } // Optional filter property
    public int? Page { get; set; }     // Optional pagination property
    public int? PageSize { get; set; } // Optional pagination property
}
