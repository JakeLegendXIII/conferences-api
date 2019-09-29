using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Models
{
    public class ConferencesResponse
    {
        [JsonProperty("_embedded")]
        public List<ConferencesSummaryItem> Embedded { get; set; }
        public string TopicFilter { get; set; }
        public int Count { get; set; }
    }

    public class ConferencesSummaryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FocusTopic { get; set; }
    }
}
