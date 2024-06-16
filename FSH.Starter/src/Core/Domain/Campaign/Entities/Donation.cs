using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class Donation
{
    public Guid DonationId { get; set; }
    public Guid CampaignId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DonationDate { get; set; }
    public Guid DonorId { get; set; }

    public Campaign Campaign { get; set; }
    public Fundraiser Donor { get; set; }
    public ICollection<DonationStudent> DonationStudents { get; set; }
    public ICollection<Configurations> Configurations { get; set; }
}