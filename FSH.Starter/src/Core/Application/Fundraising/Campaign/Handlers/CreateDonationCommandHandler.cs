using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateDonationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    //TODO: refactor this to update balances
    //public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    //{
    //    var campaign = await _context.Campaigns
    //        .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId, cancellationToken);

    //    if (campaign == null)
    //    {
    //        throw new NotFoundException(nameof(Campaign));
    //    }

    //    var donor = await _context.Fundraisers.FindAsync(request.DonorId);
    //    if (donor == null)
    //    {
    //        throw new NotFoundException(nameof(Fundraiser));
    //    }

    //    var donation = new Donation
    //    {
    //        DonationId = Guid.NewGuid(),
    //        CampaignId = request.CampaignId,
    //        Amount = request.Amount,
    //        DonationDate = request.DonationDate,
    //        DonorId = request.DonorId
    //    };

    //    _context.Donations.Add(donation);

    //    // Find the account associated with the campaign
    //    var account = await _context.Accounts
    //        .FirstOrDefaultAsync(a => a.Campaigns.Any(c => c.CampaignId == request.CampaignId), cancellationToken);

    //    if (account != null)
    //    {
    //        account.Balance += request.Amount;
    //    }
    //    else
    //    {
    //        throw new NotFoundException(nameof(Account));
    //    }

    //    await _context.SaveChangesAsync(cancellationToken);

    //    return donation.DonationId;
    //}


    public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _context.Campaigns
            .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId, cancellationToken);
        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        var donor = await _context.Fundraisers
            .Include(f => f.Account)
            .FirstOrDefaultAsync(f => f.FundraiserId == request.DonorId, cancellationToken);
        if (donor == null)
        {
            throw new NotFoundException(nameof(Fundraiser));
        }

        var donation = new Donation
        {
            DonationId = Guid.NewGuid(),
            CampaignId = campaign.CampaignId,
            Amount = request.Amount,
            DonationDate = request.DonationDate,
            DonorId = request.DonorId
        };

        _context.Donations.Add(donation);

        // Update the account balance
        if (donor.Account != null)
        {
            donor.Account.Balance += request.Amount;
            // You might want to add more logic here, like updating LastDonationDate
            // donor.Account.LastDonationDate = request.DonationDate;
        }
        else
        {
            throw new NotFoundException(nameof(Account));
        }

        await _context.SaveChangesAsync(cancellationToken);

        return donation.DonationId;
    }

    //public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    //{
    //    var campaign = await _context.Campaigns.FindAsync(request.CampaignId);
    //    if (campaign == null)
    //    {
    //        throw new NotFoundException(nameof(Campaign));
    //    }

    //    var donor = await _context.Fundraisers.FindAsync(request.DonorId);
    //    if (donor == null)
    //    {
    //        throw new NotFoundException(nameof(Fundraiser));
    //    }

    //    var donation = new Donation
    //    {
    //        DonationId = Guid.NewGuid(),
    //        CampaignId = request.CampaignId,
    //        Amount = request.Amount,
    //        DonationDate = request.DonationDate,
    //        DonorId = request.DonorId
    //    };

    //    _context.Donations.Add(donation);
    //    await _context.SaveChangesAsync(cancellationToken);

    //    return donation.DonationId;
    //}


}

