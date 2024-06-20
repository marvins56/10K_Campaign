using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class AccountDto
{
    public Guid AccountId { get; set; }
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }
}

