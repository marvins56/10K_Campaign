using FSH.Starter.Application.Fundraising.Campaign.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateConfigurationCommandHandler : IRequestHandler<UpdateConfigurationCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateConfigurationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateConfigurationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var configuration = await _context.Configurations
            .FirstOrDefaultAsync(c => c.ConfigurationsId == request.ConfigurationsId, cancellationToken);

            if (configuration == null)
            {
                throw new NotFoundException("Configuration not found.");
            }

            configuration.ConfigType = request.ConfigType;
            configuration.ConfigValue = request.ConfigValue;
            configuration.CampaignId = request.CampaignId;
            configuration.DonationId = request.DonationId;
            configuration.Description = request.Description;
            configuration.IsActive = request.IsActive;
            configuration.MinDonationAmount = request.MinDonationAmount;
            configuration.MaxDonationAmount = request.MaxDonationAmount;
            configuration.MinNumberOfStudents = request.MinNumberOfStudents;
            configuration.MaxNumberOfStudents = request.MaxNumberOfStudents;
            configuration.StartDate = request.StartDate;
            configuration.EndDate = request.EndDate;
            configuration.AccountingCode = request.AccountingCode;
            configuration.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            throw new UpdateFailureException("Failed to update configuration", ex);
        }
    }
}

