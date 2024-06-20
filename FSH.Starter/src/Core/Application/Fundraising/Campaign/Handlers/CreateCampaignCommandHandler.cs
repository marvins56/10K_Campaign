using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Domain.Fundraising.Entities;
using FSH.Starter.Application.Fundraising.Campaign.Commands;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCampaignCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = new FSH.Starter.Domain.Fundraising.Entities.Campaign
        {
            CampaignName = request.CampaignName,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        _context.Campaigns.Add(campaign);
        await _context.SaveChangesAsync(cancellationToken);

        return campaign.CampaignId;
    }
}
