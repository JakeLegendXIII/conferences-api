using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Domain
{
    public class Conference
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Attending { get; set; }

        public bool Speaking { get; set; }

        public Topic FocusTopic { get; set; }
    }

    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
