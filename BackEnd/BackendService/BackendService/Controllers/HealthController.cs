using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        //// GET api/health/
        //[HttpGet]
        //public ActionResult<bool> Get()
        //{
        //    return true;
        //}

        // GET api/health
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Ready", "Live" };
        }

        // GET api/health/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "healthy";
        }

        // POST api/health
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/health/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/health/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
