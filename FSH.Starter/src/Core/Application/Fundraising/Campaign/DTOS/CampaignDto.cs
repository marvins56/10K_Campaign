using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
//public class CampaignDto
//{
//    public DefaultIdType CampaignId { get; set; }
//    public string CampaignName { get; set; }
//    public DateTime StartDate { get; set; }
//    public DateTime EndDate { get; set; }
//    public string Description { get; set; }
//}

public class CampaignDto
{
    public Guid CampaignId { get; set; }
    public string CampaignName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public decimal TargetAmount { get; set; }
    public List<DonationDto> Donations { get; set; }
    public List<CampaignStudentDto> CampaignStudents { get; set; }
    public List<ConfigurationDto> Configurations { get; set; }
}