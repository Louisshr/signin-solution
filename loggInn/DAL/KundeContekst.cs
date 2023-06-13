using System;
using loggInn.Model;
using Microsoft.EntityFrameworkCore;

namespace loggInn.DAL
{    
    public class KundeContekst : DbContext
    {
        public KundeContekst(DbContextOptions<KundeContekst> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Users> Users { get; set; }
    }
}

