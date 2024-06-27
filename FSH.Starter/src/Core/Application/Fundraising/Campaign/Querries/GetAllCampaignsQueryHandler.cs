using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using Microsoft.EntityFrameworkCore;

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
            .Include(c=>c.Account)
            .Include(c => c.Configurations);

       
        
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
                Configurations = _mapper.Map<List<ConfigurationDto>>(c.Configurations),
                AccountId = c.Account.AccountId,
                AccountName = c.Account.AccountName

            })
            .ToListAsync(cancellationToken);

        return campaigns;
    } 
}