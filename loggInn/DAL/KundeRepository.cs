using System;
namespace loggInn.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly KundeContekst _db;

        public KundeRepository(KundeContekst db)
        {
            _db = db;
        }
    }
}

