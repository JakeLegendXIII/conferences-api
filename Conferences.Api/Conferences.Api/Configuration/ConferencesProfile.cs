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
            CreateMap<Conference, ConferenceGetResponse>()
                .ForMember(dest => dest.FocusTopic, opt => opt.MapFrom(s => s.FocusTopic.Name));
            CreateMap<ConferenceCreate, Conference>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FocusTopic, opt => opt.Ignore())
                .ForMember(dest => dest.Attending, opt => opt.MapFrom((s) => true))
                .ForMember(dest => dest.Speaking, opt => opt.MapFrom((s) => true));
        }        
    }
}
