using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class CampaignStudent
{
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}

