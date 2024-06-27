using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class AttachCampaignToAccountCommandHandler : IRequestHandler<AttachCampaignToAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public AttachCampaignToAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AttachCampaignToAccountCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _context.Campaigns.FindAsync(request.CampaignId);
        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        if (campaign.AccountId != null && campaign.AccountId != Guid.Empty)
        {
            throw new InvalidOperationException("This campaign is already assigned to an account.");
        }

        var account = await _context.Accounts.FindAsync(request.AccountId);
        if (account == null)
        {
            throw new NotFoundException(nameof(Account));
        }

        // Check if the account already has the campaign
        var existingCampaign = await _context.Campaigns
            .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId && c.AccountId == request.AccountId, cancellationToken);

        if (existingCampaign != null)
        {
            throw new InvalidOperationException("This account is already assigned to the campaign.");
        }

        campaign.AccountId = request.AccountId;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
