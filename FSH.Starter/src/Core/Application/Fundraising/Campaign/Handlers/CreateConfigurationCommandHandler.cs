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
public class CreateConfigurationCommandHandler : IRequestHandler<CreateConfigurationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateConfigurationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Check for duplicates
            var existingConfiguration = await _context.Configurations
                .Where(c => c.ConfigType == request.ConfigType &&
                            c.ConfigValue == request.ConfigValue &&
                            c.CampaignId == request.CampaignId &&
                            c.DonationId == request.DonationId)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingConfiguration != null)
            {
                throw new DuplicateConfigurationException("A similar configuration already exists.");
            }

            var configuration = new Configurations
            {
                ConfigurationsId = Guid.NewGuid(),
                ConfigType = request.ConfigType,
                ConfigValue = request.ConfigValue,
                CampaignId = request.CampaignId,
                DonationId = request.DonationId,
                Description = request.Description,
                CreatedDate = DateTime.UtcNow,
                IsActive = request.IsActive,
                MinDonationAmount = request.MinDonationAmount,
                MaxDonationAmount = request.MaxDonationAmount,
                MinNumberOfStudents = request.MinNumberOfStudents,
                MaxNumberOfStudents = request.MaxNumberOfStudents,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                AccountingCode = request.AccountingCode
            };

            _context.Configurations.Add(configuration);
            await _context.SaveChangesAsync(cancellationToken);

            return configuration.ConfigurationsId;
        }
        catch (Exception ex)
        {
            throw new CreateFailureException("Failed to create configuration", ex);
        }
    }
}

