using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class FundraiserDto
{
    public Guid FundraiserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid AccountId { get; set; }
    public string AccountName { get; set; }
    public List<DonationDto> Donations { get; set; }

}
