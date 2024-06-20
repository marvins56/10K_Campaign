using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class UpdateCampaignStudentCommand : IRequest<Unit>
{
    public DefaultIdType Id { get; set; }
    public DefaultIdType CampaignId { get; set; }
    public DefaultIdType StudentId { get; set; }
}