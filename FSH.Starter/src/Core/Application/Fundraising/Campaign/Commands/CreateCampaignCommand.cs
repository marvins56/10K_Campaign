using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Domain.Fundraising.Entities;
using MediatR;


namespace FSH.Starter.Application.Fundraising.Campaign.Commands;
public class CreateCampaignCommand : IRequest<DefaultIdType>
{
    public string CampaignName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TargetAmount { get; set; }
    public Guid AccountId { get; set; }


    public CreateCampaignCommand(CreateCampaignRequest request)
    {
        CampaignName = request.CampaignName;
        Description = request.Description;
        StartDate = request.StartDate;
        EndDate = request.EndDate;
        TargetAmount = request.TargetAmount;
        AccountId = request.AccountId;
    }
}
