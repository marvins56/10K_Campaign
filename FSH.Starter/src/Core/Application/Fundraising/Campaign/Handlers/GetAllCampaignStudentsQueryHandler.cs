using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class GetAllCampaignStudentsQueryHandler : IRequestHandler<GetAllCampaignStudentsQuery, List<CampaignStudentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCampaignStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CampaignStudentDto>> Handle(GetAllCampaignStudentsQuery request, CancellationToken cancellationToken)
    {
        var campaignStudents = await _context.CampaignStudents
            .Include(cs => cs.Campaign)
            .Include(cs => cs.Student)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<CampaignStudentDto>>(campaignStudents);
    }
}