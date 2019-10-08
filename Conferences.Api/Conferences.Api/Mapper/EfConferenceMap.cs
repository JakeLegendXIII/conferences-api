using AutoMapper;
using AutoMapper.QueryableExtensions;
using Conferences.Api.Domain;
using Conferences.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Mapper
{
    public class EfConferenceMap : IMapConferences
    {
        ConferenceDataContext _context;
        IMapper _mapper;
        MapperConfiguration _config;

        public EfConferenceMap(ConferenceDataContext context, IMapper mapper, MapperConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        } 

        public async Task<ConferencesResponse> GetAllConferences(string topic)
        {
            var query = GetConferences();

            if (topic != null)
            {
                query = query.Where(c => c.FocusTopic.Name == topic);
            }
            var response = new ConferencesResponse
            {
                Embedded = await query
                .ProjectTo<ConferencesSummaryItem>(_config)
                .ToListAsync()
            };
            response.Count = response.Embedded.Count;
            response.TopicFilter = topic;

            return response;
        }

        public async Task<ConferenceGetResponse> GetConferenceById(int id)
        {
            var result = await GetConferences()
                .Where(c => c.Id == id)
                .ProjectTo<ConferenceGetResponse>(_config)
                .SingleOrDefaultAsync();
            return result;
        }

        public async Task<ConferenceGetResponse> Add(ConferenceCreate conferenceToAdd)
        {
            var conference = _mapper.Map<Conference>(conferenceToAdd);
            var topic = await _context.Topics
                .SingleOrDefaultAsync(t => t.Name == conferenceToAdd.FocusTopic);
            if (topic == null)
            {
                topic = new Topic { Name = conferenceToAdd.FocusTopic };
            }
            conference.FocusTopic = topic; // Will add new topic to DB too
            _context.Add(conference);
            await _context.SaveChangesAsync();
            return _mapper.Map<ConferenceGetResponse>(conference);
        }

        public async Task Remove(int id)
        {
            var conference = await GetConferences().SingleOrDefaultAsync(c => c.Id == id);
            if (conference != null)
            {
                _context.Remove(conference);
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<Conference> GetConferences()
        {
            return _context.Conferences;
        }

       
    }
}
