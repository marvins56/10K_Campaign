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
public class GetFundraiserByIdQueryHandler : IRequestHandler<GetFundraiserByIdQuery, FundraiserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFundraiserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FundraiserDto> Handle(GetFundraiserByIdQuery request, CancellationToken cancellationToken)
    {
        var fundraiser = await _context.Fundraisers
            .Include(f => f.Account)
            .Include(f => f.Donations)
            .FirstOrDefaultAsync(f => f.FundraiserId == request.FundraiserId, cancellationToken);

        if (fundraiser == null)
        {
            throw new NotFoundException(nameof(Fundraiser));
        }

        return _mapper.Map<FundraiserDto>(fundraiser);
    }
}
