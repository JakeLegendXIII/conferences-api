using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Domain
{
    public class ConferenceDataContext : DbContext
    {
        public ConferenceDataContext(DbContextOptions<ConferenceDataContext> ctx) : base(ctx) { }

        public virtual DbSet<Conference> Conferences { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }
    }
}
