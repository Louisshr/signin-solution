using System;
using loggInn.DAL;
using loggInn.Model;
using Microsoft.AspNetCore.Mvc;

namespace loggInn.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _db;

        public KundeController(IKundeRepository db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> signIn(User user)
        {
            Console.WriteLine("BRUKERNAV: " + user.username);
            Console.WriteLine("PASSORD: " + user.password);

            return Ok(true);
        }
    }
}

