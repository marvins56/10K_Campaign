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
public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, CampaignDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCampaignByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CampaignDto> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
    {
        var campaign = await _context.Campaigns
            .Include(c => c.Donations)
            .Include(c => c.CampaignStudents)
                .ThenInclude(cs => cs.Student)
            .Include(c => c.Configurations)
            .FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId, cancellationToken);

        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        return _mapper.Map<CampaignDto>(campaign);
    }
}