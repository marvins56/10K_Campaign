using FSH.Starter.Application.Fundraising.Campaign.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Validators;
public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(v => v.StudentId).NotEmpty().WithMessage("Student ID is required.");
        RuleFor(v => v.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(v => v.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(v => v.Email).EmailAddress().WithMessage("A valid email is required.");
        RuleFor(v => v.Phone).NotEmpty().WithMessage("Phone number is required.");
    }
}

