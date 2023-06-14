using System;
using loggInn.Model;

namespace loggInn.DAL
{
    public class DBinit
    {
        public static void Initialize(KundeContekst context)
        {
            Console.WriteLine("inne i initialize");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // creating a user
            Users admin = new Users();
            admin.Username = "admin";
            string password = "admin1";
            byte[] salt = KundeRepository.createSalt();
            byte[] hash = KundeRepository.createHash(password, salt);
            admin.Password = hash;
            admin.Salt = salt;
            context.Users.Add(admin);
            context.SaveChanges();
        }          
    }
}

