using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class GetDonationStudentByIdQueryHandler : IRequestHandler<GetDonationStudentByIdQuery, DonationStudentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDonationStudentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DonationStudentDto> Handle(GetDonationStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var donationStudent = await _context.DonationStudents
            .FirstOrDefaultAsync(ds => ds.DonationId == request.DonationId && ds.StudentId == request.StudentId, cancellationToken);

        if (donationStudent == null)
        {
            throw new NotFoundException(nameof(DonationStudent));
        }

        return _mapper.Map<DonationStudentDto>(donationStudent);
    }
}
