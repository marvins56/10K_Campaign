using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class GetCampaignStudentByIdQueryHandler : IRequestHandler<GetCampaignStudentByIdQuery, CampaignStudentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCampaignStudentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CampaignStudentDto> Handle(GetCampaignStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var campaignStudent = await _context.CampaignStudents
            .FirstOrDefaultAsync(cs => cs.Id == request.Id, cancellationToken);

        if (campaignStudent == null)
        {
            throw new NotFoundException(nameof(CampaignStudent));
        }

        return _mapper.Map<CampaignStudentDto>(campaignStudent);
    }
}
