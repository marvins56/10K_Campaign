using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetAllDonationStudentsQuery : IRequest<List<DonationStudentDto>>
{
}

public class GetAllDonationStudentsQueryHandler : IRequestHandler<GetAllDonationStudentsQuery, List<DonationStudentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllDonationStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DonationStudentDto>> Handle(GetAllDonationStudentsQuery request, CancellationToken cancellationToken)
    {
        var donationStudents = await _context.DonationStudents.ToListAsync(cancellationToken);
        return _mapper.Map<List<DonationStudentDto>>(donationStudents);
    }
}

