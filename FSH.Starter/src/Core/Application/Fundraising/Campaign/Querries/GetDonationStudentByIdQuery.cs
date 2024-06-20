using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetDonationStudentByIdQuery : IRequest<DonationStudentDto>
{
    public Guid DonationId { get; set; }
    public Guid StudentId { get; set; }
}
