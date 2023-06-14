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
            try
            {
                bool credentialsOK = await _db.signIn(user);

                if (credentialsOK)
                {
                    return Ok(true);
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("error on backend");
            }
                          
        }

        [HttpPost]
        public async Task<ActionResult<bool>> register(User user)
        {
            try
            {
                bool registerOK = await _db.register(user);
                return registerOK ? Ok(true) : Ok(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("error on backend");
            }
        }
    }
}

