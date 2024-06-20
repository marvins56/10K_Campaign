using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Domain.Fundraising.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FSH.Starter.Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Fundraiser, FundraiserDto>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.AccountName));
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<CreateStudentCommand, Student>();
        CreateMap<DonationStudent, DonationStudentDto>();
        CreateMap<Donation, DonationDto>();
        CreateMap<CreateDonationCommand, Donation>();
        CreateMap<UpdateDonationCommand, Donation>();
    }
}