using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers.Querries;
public class GetAllCampaignsQueryHandler : IRequestHandler<GetAllCampaignsQuery, List<CampaignDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCampaignsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Fundraising.Entities.Campaign> query = _context.Campaigns;

        // Apply filters if provided
        if (!string.IsNullOrEmpty(request.Filter))
        {
            query = query.Where(c => c.CampaignName.Contains(request.Filter) || c.Description.Contains(request.Filter)); // Example filter
        }

        // Apply pagination if requested
        if (request.Page.HasValue && request.PageSize.HasValue)
        {
            query = query.Skip((request.Page.Value - 1) * request.PageSize.Value)
                         .Take(request.PageSize.Value);
        }

        // Project to DTO
        var campaigns = await query
            .Select(c => new CampaignDto
            {
                CampaignId = c.CampaignId,
                CampaignName = c.CampaignName,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
                // Add other properties as needed
            })
            .ToListAsync(cancellationToken);

        return campaigns;
    }
}