using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetAllCampaignsQueryHandler : IRequestHandler<GetAllCampaignsQuery, List<CampaignDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCampaignsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Campaigns
            .Include(c => c.Donations)
            .Include(c => c.CampaignStudents)
            .Include(c => c.Configurations);

        // Apply filters if provided
        if (!string.IsNullOrEmpty(request.Filter))
        {
            query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Domain.Fundraising.Entities.Campaign, ICollection<Domain.Fundraising.Entities.Configurations>>)query.Where(c => c.CampaignName.Contains(request.Filter) || c.Description.Contains(request.Filter));
        }

        // Apply pagination if requested
        if (request.Page.HasValue && request.PageSize.HasValue)
        {
            query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Domain.Fundraising.Entities.Campaign, ICollection<Domain.Fundraising.Entities.Configurations>>)query.Skip((request.Page.Value - 1) * request.PageSize.Value)
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
                EndDate = c.EndDate,
                Donations = _mapper.Map<List<DonationDto>>(c.Donations),
                CampaignStudents = _mapper.Map<List<CampaignStudentDto>>(c.CampaignStudents),
                Configurations = _mapper.Map<List<ConfigurationDto>>(c.Configurations)
            })
            .ToListAsync(cancellationToken);

        return campaigns;
    } //public async Task<List<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
    //{
    //    IQueryable<Domain.Fundraising.Entities.Campaign> query = _context.Campaigns;

    //    // Apply filters if provided
    //    if (!string.IsNullOrEmpty(request.Filter))
    //    {
    //        query = query.Where(c => c.CampaignName.Contains(request.Filter) || c.Description.Contains(request.Filter)); // Example filter
    //    }

    //    // Apply pagination if requested
    //    if (request.Page.HasValue && request.PageSize.HasValue)
    //    {
    //        query = query.Skip((request.Page.Value - 1) * request.PageSize.Value)
    //                     .Take(request.PageSize.Value);
    //    }

    //    // Project to DTO
    //    var campaigns = await query
    //        .Select(c => new CampaignDto
    //        {
    //            CampaignId = c.CampaignId,
    //            CampaignName = c.CampaignName,
    //            Description = c.Description,
    //            StartDate = c.StartDate,
    //            EndDate = c.EndDate
    //        })
    //        .ToListAsync(cancellationToken);

    //    return campaigns;
    //}
}