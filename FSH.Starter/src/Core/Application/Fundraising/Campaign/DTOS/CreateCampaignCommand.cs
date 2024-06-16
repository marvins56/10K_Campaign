using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace FSH.Starter.Application.Fundraising.Campaign.DTOS;
public class CreateCampaignCommand : IRequest<Guid>
{
    public string CampaignName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public CreateCampaignCommand(CreateCampaignRequest request)
    {
        CampaignName = request.CampaignName;
        Description = request.Description;
        StartDate = request.StartDate;
        EndDate = request.EndDate;
    }
}
