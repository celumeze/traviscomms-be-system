using AutoMapper;
using System;
using System.Linq;
using TravisComms.Api.Dto;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.IdentityModels;

namespace TravisComms.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddAccountHolderDto, AccountHolder>();
            CreateMap<CompanyDto, Company>();
            CreateMap<AddAccountHolderDto, MainUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress))                
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src=>src.EmailAddress));
            CreateMap<SubscriptionTypeDto, SubscriptionType>();
            CreateMap<SubscriptionType, SubscriptionTypeDto>();
            CreateMap<AccountHolderRole, AccountHolderRoleDto>();
            CreateMap<AccountHolderRoleDto, AccountHolderRole>();
            CreateMap<AddContactDto, Contact>();
            CreateMap<Contact, AddContactDto>();
        }
    }
}
