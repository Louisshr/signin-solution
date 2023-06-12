using System;
using Microsoft.EntityFrameworkCore;

namespace loggInn.DAL
{
    public class Bruker
    {
        public int Id { get; set; }
        public string? navn { get; set; }
    }

    public class KundeContekst : DbContext
    {
        public KundeContekst(DbContextOptions<KundeContekst> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Bruker> Brukere { get; set; }
    }
}

