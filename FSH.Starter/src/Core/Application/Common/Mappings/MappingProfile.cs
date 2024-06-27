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
        // Fundraiser to FundraiserDto with custom AccountName mapping
        CreateMap<Fundraiser, FundraiserDto>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.AccountName))
             .ForMember(dest => dest.Donations, opt => opt.MapFrom(src => src.Donations));


        // Student mappings
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<CreateStudentCommand, Student>();

        // DonationStudent mappings
        CreateMap<DonationStudent, DonationStudentDto>();

        // Donation mappings
        //CreateMap<Donation, DonationDto>();
        CreateMap<Donation, DonationDto>()
           .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.Campaign.CampaignId))
           .ForMember(dest => dest.DonorId, opt => opt.MapFrom(src => src.DonorId))
           // Map other properties as needed
           .ReverseMap(); // If two-way mapping is required



        CreateMap<CreateDonationCommand, Donation>()
            .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.CampaignId))
           .ForMember(dest => dest.DonorId, opt => opt.MapFrom(src => src.DonorId))
           // Map other properties as needed
           .ReverseMap(); // If two-way mapping is required;

        CreateMap<UpdateDonationCommand, Donation>();

        // Configuration mappings
        CreateMap<Configurations, ConfigurationDto>().ReverseMap();

        CreateMap<Campaign, CampaignDto>()
     .ForMember(dest => dest.Donations, opt => opt.MapFrom(src => src.Donations))
     .ForMember(dest => dest.CampaignStudents, opt => opt.MapFrom(src => src.CampaignStudents))
     .ForMember(dest => dest.Configurations, opt => opt.MapFrom(src => src.Configurations))
     .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account.AccountId))
     .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.AccountName))
     .ReverseMap(); // Optional if mapping from CampaignDto back to Campaign is needed


        CreateMap<Account, AccountDto>()
            .ForMember(dest => dest.Fundraisers, opt => opt.MapFrom(src => src.Fundraisers))
            // Map other properties as needed
            .ForMember(dest => dest.campaigns, opt => opt.MapFrom(src => src.Campaigns))
            .ReverseMap(); 


        // CampaignStudent mappings
        CreateMap<CampaignStudent, CampaignStudentDto>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Student));


    }


    
}