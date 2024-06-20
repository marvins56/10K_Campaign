using FSH.Starter.Application.Fundraising.Campaign.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Validators;
public class CreateDonationStudentCommandValidator : AbstractValidator<CreateDonationStudentCommand>
{
    public CreateDonationStudentCommandValidator()
    {
        RuleFor(v => v.DonationId).NotEmpty().WithMessage("Donation ID is required.");
        RuleFor(v => v.StudentId).NotEmpty().WithMessage("Student ID is required.");
    }
}

