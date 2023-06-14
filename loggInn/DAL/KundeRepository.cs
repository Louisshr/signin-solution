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
        {/*
            var csp = new RNGCryptoServiceProvider();
            var salt = new Byte[24];
            csp.GetBytes(salt);          
            return salt;*/

            
            var salt = new byte[24];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);                
            }
            return salt;            
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

        public async Task<bool> register(User user)
        {
            try
            {
                if (user.username != null && user.password != null)
                {
                    Users? foundUser = await _db.Users.FirstOrDefaultAsync(u => user.username == u.Username);
                    if (foundUser == null)
                    {
                        Users newUser = new Users();
                        newUser.Username = user.username;
                        byte[] salt = KundeRepository.createSalt();
                        byte[] hash = KundeRepository.createHash(user.password, salt);
                        newUser.Password = hash;
                        newUser.Salt = salt;

                        await _db.Users.AddAsync(newUser);
                        await _db.SaveChangesAsync();
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

