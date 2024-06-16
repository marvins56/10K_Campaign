using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCampaignCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _context.Campaigns.FindAsync(new object[] { request.CampaignId }, cancellationToken);

        if (campaign == null)
        {
            //throw an exception if the campaign is not found

            throw new NotFoundException(nameof(Campaign));
        }

        campaign.CampaignName = request.CampaignName;
        campaign.Description = request.Description;
        campaign.StartDate = request.StartDate;
        campaign.EndDate = request.EndDate;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}