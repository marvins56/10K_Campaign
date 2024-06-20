using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class CreateAccountCommand : IRequest<DefaultIdType>
{
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
}

