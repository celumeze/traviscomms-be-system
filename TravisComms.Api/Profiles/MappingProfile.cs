﻿using AutoMapper;
using TravisComms.Api.Dto;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravisComms.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientDto, AccountHolder>();
            CreateMap<CompanyDto, Company>();
            CreateMap<ClientDto, MainUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress))                
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src=>src.EmailAddress));
            CreateMap<SubscriptionTypeDto, SubscriptionType>();
            CreateMap<AccountHolderRole, ClientRoleDto>();
            CreateMap<ClientRoleDto, AccountHolderRole>();
        }
    }
}