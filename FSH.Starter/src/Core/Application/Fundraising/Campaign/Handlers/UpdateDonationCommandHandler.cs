using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDonationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _context.Donations.FindAsync(request.DonationId);
        if (donation == null)
        {
            throw new NotFoundException(nameof(Donation));
        }

        donation.CampaignId = request.CampaignId;
        donation.Amount = request.Amount;
        donation.DonationDate = request.DonationDate;
        donation.DonorId = request.DonorId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
