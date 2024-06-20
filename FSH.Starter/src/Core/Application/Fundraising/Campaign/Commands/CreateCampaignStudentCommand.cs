using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class CreateCampaignStudentCommand : IRequest<DefaultIdType>
{
    public DefaultIdType CampaignId { get; set; }
    public DefaultIdType StudentId { get; set; }
}
