using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class UpdateCampaignCommand : IRequest
{
    public Guid CampaignId { get; set; }
    public string CampaignName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public UpdateCampaignCommand(UpdateCampaignRequest request)
    {
        CampaignId = request.CampaignId;
        CampaignName = request.CampaignName;
        Description = request.Description;
        StartDate = request.StartDate;
        EndDate = request.EndDate;
    }
}
