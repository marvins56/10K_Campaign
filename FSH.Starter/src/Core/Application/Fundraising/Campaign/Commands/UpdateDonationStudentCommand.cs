using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class UpdateDonationStudentCommand : IRequest
{
    public Guid DonationId { get; set; }
    public Guid StudentId { get; set; }
}

