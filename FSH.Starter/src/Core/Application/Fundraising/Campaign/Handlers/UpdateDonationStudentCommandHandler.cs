using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateDonationStudentCommandHandler : IRequestHandler<UpdateDonationStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDonationStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDonationStudentCommand request, CancellationToken cancellationToken)
    {
        var donationStudent = await _context.DonationStudents
            .FirstOrDefaultAsync(ds => ds.DonationId == request.DonationId && ds.StudentId == request.StudentId, cancellationToken);

        if (donationStudent == null)
        {
                    throw new NotFoundException(nameof(DonationStudent));
                }

        // Assuming you want to update the DonationId or StudentId,
        // which seems unusual, but for completeness:
        donationStudent.DonationId = request.DonationId;
        donationStudent.StudentId = request.StudentId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}