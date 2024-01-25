﻿using Microsoft.EntityFrameworkCore;

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