using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
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
        var campaign = await _context.Campaigns.FindAsync(request.CampaignId);
        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        var donor = await _context.Fundraisers.FindAsync(request.DonorId);
        if (donor == null)
        {
            throw new NotFoundException(nameof(Fundraiser));
        }

        var donation = new Donation
        {
            DonationId = Guid.NewGuid(),
            CampaignId = request.CampaignId,
            Amount = request.Amount,
            DonationDate = request.DonationDate,
            DonorId = request.DonorId
        };

        _context.Donations.Add(donation);
        await _context.SaveChangesAsync(cancellationToken);

        return donation.DonationId;
    }
}

