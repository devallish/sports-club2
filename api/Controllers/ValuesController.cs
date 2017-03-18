using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Devallish.SportsClub.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger<ValuesController> _logger;
        public ValuesController(ILogger<ValuesController> logger){
            _logger = logger;
            _logger.LogInformation("Logged from the constructor of ValuesController");
            _logger.LogWarning("Some warning from the constructor of ValuesController");
            _logger.LogError("Some error from the constructor of ValuesController");
            _logger.LogCritical("Some critical from the constructor of ValuesController");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get() { 
            _logger.LogInformation("Get method of ValuesController");
            var result = new string[] { "This has", "launched", DateTime.Now.ToString()};
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) => "value";

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
