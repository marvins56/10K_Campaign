using FSH.Starter.Domain.Fundraising.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateFundraiserCommandHandler : IRequestHandler<UpdateFundraiserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFundraiserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateFundraiserCommand request, CancellationToken cancellationToken)
    {
        var fundraiser = await _context.Fundraisers.FindAsync(new object[] { request.FundraiserId }, cancellationToken);

        if (fundraiser == null)
        {
            throw new NotFoundException(nameof(Fundraiser));
        }

        var account = await _context.Accounts.FindAsync(new object[] { request.AccountId }, cancellationToken);

        if (account == null)
        {
            throw new NotFoundException(nameof(Account));
        }

        fundraiser.FirstName = request.FirstName;
        fundraiser.LastName = request.LastName;
        fundraiser.Email = request.Email;
        fundraiser.Phone = request.Phone;
        fundraiser.AccountId = request.AccountId;
        fundraiser.Account = account;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
