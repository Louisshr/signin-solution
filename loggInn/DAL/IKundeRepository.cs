using System;
using loggInn.Model;

namespace loggInn.DAL
{
    public interface IKundeRepository
    {
        Task<bool> signIn(User user);
    }
}

