using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class Campaign
{
    public Guid CampaignId { get; set; }
    public string CampaignName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public decimal TargetAmount { get; set; }

    public ICollection<Donation> Donations { get; set; }
    public ICollection<CampaignStudent> CampaignStudents { get; set; }
    public ICollection<Configurations> Configurations { get; set; }
}