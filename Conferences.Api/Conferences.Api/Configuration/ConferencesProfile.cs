using AutoMapper;
using Conferences.Api.Domain;
using Conferences.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Configuration
{
    public class ConferencesProfile : Profile
    {
        public ConferencesProfile()
        {
            CreateMap<Conference, ConferencesSummaryItem>()
                        .ForMember(dest => dest.FocusTopic, opt => opt.MapFrom(s => s.FocusTopic.Name));

        }        
    }
}
