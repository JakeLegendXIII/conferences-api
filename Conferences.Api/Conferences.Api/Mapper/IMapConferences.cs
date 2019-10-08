using System.Threading.Tasks;
using Conferences.Api.Models;

namespace Conferences.Api.Mapper
{
    public interface IMapConferences
    {
        Task<ConferencesResponse> GetAllConferences(string topic);
        Task<ConferenceGetResponse> GetConferenceById(int id);
        Task<ConferenceGetResponse> Add(ConferenceCreate conferenceToAdd);
    }
}