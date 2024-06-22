using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class UpdateConfigurationCommand : IRequest
{
    public Guid ConfigurationsId { get; set; }
    public string ConfigType { get; set; }
    public string ConfigValue { get; set; }
    public Guid? CampaignId { get; set; }
    public Guid? DonationId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public decimal? MinDonationAmount { get; set; }
    public decimal? MaxDonationAmount { get; set; }
    public int? MinNumberOfStudents { get; set; }
    public int? MaxNumberOfStudents { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AccountingCode { get; set; }
}

