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

    public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        // Validate campaign existence
        var campaign = await _context.Campaigns
            .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId, cancellationToken);

        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        // Validate donor existence and account association
        var donor = await _context.Fundraisers
            .Include(f => f.Account) // Ensure Account is loaded
            .FirstOrDefaultAsync(f => f.FundraiserId == request.DonorId, cancellationToken);

        if (donor == null || donor.Account == null)
        {
            throw new NotFoundException(nameof(Account));
        }

        // Ensure donor's account matches the campaign's account
        if (campaign.AccountId != donor.Account.AccountId)
        {
            throw new InvalidOperationException("Donor's account does not match the campaign's account.");
        }

        // Validate campaign-donor relationship
        var account = await _context.Accounts
            .Include(a => a.Fundraisers)
            .Include(a => a.Campaigns)
            .FirstOrDefaultAsync(a => a.AccountId == campaign.AccountId);

        if (account == null)
        {
            throw new NotFoundException(nameof(Account));
        }

        // Check if the donor is a fundraiser for the campaign
        if (!account.Fundraisers.Any(f => f.FundraiserId == donor.FundraiserId))
        {
            throw new InvalidOperationException("Donor is not registered as a fundraiser for this campaign.");
        }

        if (request.Amount <= 0)
        {
            throw new InvalidOperationException("Donation amount must be greater than zero.");
        }

        // Proceed with creating the donation
        var donation = new Donation
        {
            DonationId = Guid.NewGuid(),
            CampaignId = campaign.CampaignId,
            Amount = request.Amount,
            DonationDate = request.DonationDate,
            DonorId = request.DonorId
        };

        // Add the donation to the campaign's donations collection
        _context.Donations.Add(donation);

        // Update the donor's account balance
        donor.Account.Balance += request.Amount;

        // Save changes to the database
        await _context.SaveChangesAsync(cancellationToken);

        return donation.DonationId;
    }

    //public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    //{
    //    // Validate campaign existence
    //    var campaign = await _context.Campaigns
    //        .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId, cancellationToken);

    //    if (campaign == null)
    //    {
    //        throw new NotFoundException(nameof(Campaign));
    //    }

    //    // Validate donor existence and account association
    //    var donor = await _context.Fundraisers
    //        .Include(f => f.Account)
    //        .FirstOrDefaultAsync(f => f.FundraiserId == request.DonorId, cancellationToken);

    //    if (donor == null || donor.Account == null)
    //    {
    //        throw new NotFoundException(nameof(Account));
    //    }

    //    if (donor.Account.AccountId != campaign.AccountId)
    //    {
    //        throw new InvalidOperationException("Donor's account does not match the provided accountId.");
    //    }

    //    // Validate campaign-donor relationship if required
    //   //Ensuring the donor is registered as a fundraiser for the campaign

    //    var memberIsAttchedToCampaign = _context.Accounts
    //        .Include(a => a.Fundraisers)
    //        .Include(a => a.Campaigns)
    //        .FirstOrDefault(a => a.AccountId == campaign.AccountId);

    //    if(memberIsAttchedToCampaign == null)
    //    {
    //        throw new InvalidOperationException("Donor is not attached to the campaign.");
    //    }

    //    //check if the donor is a fundraiser for the campaign
    //    if(!memberIsAttchedToCampaign.Fundraisers.Any(f => f.FundraiserId == donor.FundraiserId))
    //    {
    //        throw new InvalidOperationException("Donor is not registered as a fundraiser for this campaign.");
    //    }

    //    if (request.Amount <= 0)
    //    {
    //        throw new InvalidOperationException("Donation amount must be greater than zero.");
    //    }

    //    // Proceed with creating the donation
    //    var donation = new Donation
    //    {
    //        DonationId = Guid.NewGuid(),
    //        CampaignId = campaign.CampaignId,
    //        Amount = request.Amount,
    //        DonationDate = request.DonationDate,
    //        DonorId = request.DonorId
    //    };

    //    // Add the donation to the campaign's donations collection
    //    campaign.Donations.Add(donation);

    //    // Update the donor's account balance
    //    donor.Account.Balance += request.Amount;

    //    // Save changes to the database
    //    await _context.SaveChangesAsync(cancellationToken);

    //    return donation.DonationId;
    //}

}

