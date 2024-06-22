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
public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllDonationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DonationDto>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
    {
        //var donations = await _context.Donations.ToListAsync(cancellationToken);
        var donations = await _context.Donations
                .Include(d => d.Campaign)
                .Include(d => d.Donor)
                .ToListAsync(cancellationToken);

        return _mapper.Map<List<DonationDto>>(donations);
    }
}