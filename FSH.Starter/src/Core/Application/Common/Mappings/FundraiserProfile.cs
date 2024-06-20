using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Domain.Fundraising.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Common.Mappings;
public class FundraiserProfile : Profile
{
    public FundraiserProfile()
    {
        CreateMap<Account, AccountDto>();

    }
}

