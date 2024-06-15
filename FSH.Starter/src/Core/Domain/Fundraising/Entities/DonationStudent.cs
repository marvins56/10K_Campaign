using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class DonationStudent
{
    public Guid DonationId { get; set; }
    public Donation Donation { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
