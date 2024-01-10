using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THEJOB.Cachorro.Domain;

namespace THEJOB.Cachorro.Repository
{
    public class CachorroContext : DbContext
    {
        public CachorroContext(DbContextOptions<CachorroContext> options) : base(options)
        {
        }

        public DbSet<Domain.Cachorro> Cachorros { get; set; }
        public DbSet<Domain.Tutor> Tutors { get; set; }

    }
}
