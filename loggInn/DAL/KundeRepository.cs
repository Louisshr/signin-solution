using System;
using System.Security.Cryptography;
using loggInn.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace loggInn.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly KundeContekst _db;

        public KundeRepository(KundeContekst db)
        {
            _db = db;
        }

        public static byte[] createHash(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 100,
                numBytesRequested: 32
                );
        }

        public static byte[] createSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new Byte[24];
            csp.GetBytes(salt);          
            return salt;

            /*
             * hvis koden under brukes, kan koden over fjernes
             * 
            var salt = new byte[24];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);                
            }
            return salt;
            */

        }

        public async Task<bool> signIn(User user)
        {
            try
            {
                Users? foundUser = await _db.Users.FirstOrDefaultAsync(u => u.Username == user.username);
                if (foundUser != null)
                {
                    byte[] hash = createHash(user.password, foundUser.Salt);
                    bool ok = hash.SequenceEqual(foundUser.Password);
                    if (ok)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

