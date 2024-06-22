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
public class GetAllFundraisersQueryHandler : IRequestHandler<GetAllFundraisersQuery, List<FundraiserDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllFundraisersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FundraiserDto>> Handle(GetAllFundraisersQuery request, CancellationToken cancellationToken)
    {
        var fundraisers = await _context.Fundraisers
            .Include(f => f.Account)
            .Include(f => f.Donations)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<FundraiserDto>>(fundraisers);
    }
}
