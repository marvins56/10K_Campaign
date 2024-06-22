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
public class CreateDonationStudentCommandHandler : IRequestHandler<CreateDonationStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateDonationStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateDonationStudentCommand request, CancellationToken cancellationToken)
    {

        try
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
            //check if that student has already been assigned to that donation
            var donationStudentExists = await _context.DonationStudents
                .AnyAsync(ds => ds.DonationId == request.DonationId && ds.StudentId == request.StudentId, cancellationToken);
            if (donationStudentExists)
            {
                throw new ResultExistsException(nameof(Student));
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
