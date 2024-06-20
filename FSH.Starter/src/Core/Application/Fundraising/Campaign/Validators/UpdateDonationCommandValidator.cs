using FSH.Starter.Application.Fundraising.Campaign.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Validators;
public class UpdateDonationCommandValidator : AbstractValidator<UpdateDonationCommand>
{
    public UpdateDonationCommandValidator()
    {
        RuleFor(v => v.DonationId).NotEmpty();
        RuleFor(v => v.CampaignId).NotEmpty();
        RuleFor(v => v.Amount).GreaterThan(0);
        RuleFor(v => v.DonationDate).NotEmpty();
        RuleFor(v => v.DonorId).NotEmpty();
    }
}
