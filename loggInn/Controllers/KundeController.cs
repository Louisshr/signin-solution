using System;
using loggInn.DAL;
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

        [HttpGet]
        public string helloWorld()
        {
            return "Hello world";
        }
    }
}

