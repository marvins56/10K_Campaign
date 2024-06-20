using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FSH.Starter.Application.Common.Exceptions.NotFoundException;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateFundraiserCommandHandler : IRequestHandler<CreateFundraiserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateFundraiserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateFundraiserCommand request, CancellationToken cancellationToken)
    {
        // Check if the account exists
        var account = await _context.Accounts.FindAsync(new object[] { request.AccountId }, cancellationToken);

        if (account == null)
        {
            // If the account doesn't exist, throw a NotFoundException
            throw new NotFoundException(nameof(Account));
        }


        // Check if an account with the same name already exists
        if (await _context.Fundraisers.AnyAsync(a => a.Email == request.Email, cancellationToken))
        {
            throw new DuplicateAccountException(request.Email);
        }

        // Create the fundraiser
        var fundraiser = new Fundraiser
        {
            FundraiserId = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            AccountId = request.AccountId,
            Account = account
        };

        _context.Fundraisers.Add(fundraiser);
        await _context.SaveChangesAsync(cancellationToken);

        return fundraiser.FundraiserId;
    }
}
