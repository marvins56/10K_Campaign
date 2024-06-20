using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateAccountCommand : IRequest<Guid>
{
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
}

