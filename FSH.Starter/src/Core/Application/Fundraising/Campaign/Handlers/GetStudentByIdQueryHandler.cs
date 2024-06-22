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
public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .Include(s => s.CampaignStudents)
            .Include(s => s.DonationStudents)
            .FirstOrDefaultAsync(s => s.StudentId == request.StudentId, cancellationToken);

        if (student == null)
        {
            throw new NotFoundException(nameof(Student));
        }

        return _mapper.Map<StudentDto>(student);
    }
}
