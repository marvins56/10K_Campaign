using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class DonationDto
{
    public Guid DonationId { get; set; }
    public Guid CampaignId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DonationDate { get; set; }
    public Guid DonorId { get; set; }
}
