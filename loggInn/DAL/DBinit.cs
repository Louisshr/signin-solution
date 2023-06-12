using System;
namespace loggInn.DAL
{
    public class DBinit
    {
        public static void Initialize(KundeContekst context)
        {
            Console.WriteLine("inne i initialize");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();            

            Bruker user1 = new Bruker(){ navn = "thomas" };
            context.Brukere.Add(user1);
            context.SaveChanges();
        }          
    }
}

