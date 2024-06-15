using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class Configurations
{
    public Guid ConfigurationsId { get; set; }
    public string ConfigType { get; set; }
    public string ConfigValue { get; set; }
    public Guid? CampaignId { get; set; }
    public Guid? DonationId { get; set; }

    public Campaign Campaign { get; set; }
    public Donation Donation { get; set; }
}
