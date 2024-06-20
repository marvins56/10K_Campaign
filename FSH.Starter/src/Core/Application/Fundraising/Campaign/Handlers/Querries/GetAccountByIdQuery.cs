using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers.Querries;
public class GetAccountByIdQuery : IRequest<AccountDto>
{
    public Guid AccountId { get; set; }
}

