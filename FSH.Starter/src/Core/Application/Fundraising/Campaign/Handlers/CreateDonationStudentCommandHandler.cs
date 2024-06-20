using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateDonationStudentCommandHandler : IRequestHandler<CreateDonationStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateDonationStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateDonationStudentCommand request, CancellationToken cancellationToken)
    {
        var donation = await _context.Donations
            .FirstOrDefaultAsync(d => d.DonationId == request.DonationId, cancellationToken);

        if (donation == null)
        {
            throw new NotFoundException(nameof(Donation));
        }

        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.StudentId == request.StudentId, cancellationToken);

        if (student == null)
        {
            throw new NotFoundException(nameof(Student));
        }

        var donationStudent = new DonationStudent
        {
            DonationId = request.DonationId,
            StudentId = request.StudentId
        };

        _context.DonationStudents.Add(donationStudent);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
