using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
//public class Configurations
//{
//    public Guid ConfigurationsId { get; set; }
//    public string ConfigType { get; set; }
//    public string ConfigValue { get; set; }
//    public Guid? CampaignId { get; set; }
//    public Guid? DonationId { get; set; }

//    public Campaign Campaign { get; set; }
//    public Donation Donation { get; set; }
//}

public class Configurations
{
    public Guid ConfigurationsId { get; set; }
    public string ConfigType { get; set; }
    public string ConfigValue { get; set; }
    public Guid? CampaignId { get; set; }
    public Guid? DonationId { get; set; }
    public Campaign Campaign { get; set; }
    public Donation Donation { get; set; }

    // Additional Fields
    public string Description { get; set; } // To provide more information about the configuration
    public DateTime CreatedDate { get; set; } // To keep track of when the configuration was created
    public DateTime? UpdatedDate { get; set; } // To track the last update date
    public bool IsActive { get; set; } // To indicate if the configuration is active or not

    // New Suggested Fields
    public decimal? MinDonationAmount { get; set; } // Minimum donation amount for the configuration
    public decimal? MaxDonationAmount { get; set; } // Maximum donation amount for the configuration
    public int? MinNumberOfStudents { get; set; } // Minimum number of students required for the configuration
    public int? MaxNumberOfStudents { get; set; } // Maximum number of students allowed for the configuration
    public DateTime? StartDate { get; set; } // Start date for the configuration to be applicable
    public DateTime? EndDate { get; set; } // End date for the configuration to expire
    public string? AccountingCode { get; set; } // Accounting code for financial tracking
}
