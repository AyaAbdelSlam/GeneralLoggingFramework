using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingFramework.Core.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace LoggingFramework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger _logger;
        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.Log(Common.Helpers.LogType.Error, "This is first Logging Message", Common.Helpers.LogTarget.Console);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            _logger.Log(Common.Helpers.LogType.Information, "This is Second Logging Message", Common.Helpers.LogTarget.File);

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
