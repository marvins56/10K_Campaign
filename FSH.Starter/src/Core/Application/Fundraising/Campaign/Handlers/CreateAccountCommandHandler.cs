using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FSH.Starter.Application.Common.Exceptions.NotFoundException;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        // Check if an account with the same name already exists
        if (await _context.Accounts.AnyAsync(a => a.AccountName == request.AccountName, cancellationToken))
        {
            throw new DuplicateAccountException(request.AccountName);
        }


        var account = new Account
        {
            AccountId = Guid.NewGuid(),
            AccountName = request.AccountName,
            Balance = request.Balance,
            CreatedDate = DateTime.UtcNow
        };

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account.AccountId;
    }
}
