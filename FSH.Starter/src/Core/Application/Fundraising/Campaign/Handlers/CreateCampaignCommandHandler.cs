using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Domain.Fundraising.Entities;
using FSH.Starter.Application.Fundraising.Campaign.Commands;
using Microsoft.EntityFrameworkCore;

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
        try
        {
            // Check if the account exists
            var existingAccount = await _context.Accounts.FindAsync(request.AccountId);
            if (existingAccount == null)
            {
                throw new Exception($"Account with ID {request.AccountId} does not exist.");
            }

            // Check if a campaign with the same name already exists
            var existingCampaign = await _context.Campaigns
                .Where(a => a.CampaignName == request.CampaignName)
                .ToListAsync(cancellationToken);

            if (existingCampaign.Any())
            {
                throw new Exception("A campaign with the same name already exists.");
            }
            //check if the campaign is already attached to that account
            var existingCampaignAccount = await _context.Campaigns
                .Where(a => a.AccountId == request.AccountId)
                .ToListAsync(cancellationToken);
            if (existingCampaignAccount.Any())
            {
                throw new Exception("A campaign with the same name already exists.");

            }


            // Create the new campaign
            var campaign = new FSH.Starter.Domain.Fundraising.Entities.Campaign
            {
                CampaignId = Guid.NewGuid(),
                CampaignName = request.CampaignName,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TargetAmount = request.TargetAmount,
                AccountId = request.AccountId
            };

            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync(cancellationToken);

            return campaign.CampaignId;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create campaign: {ex.Message}");
        }
    }


}
