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
    public class HealthzController : ControllerBase
    {

        //// GET api/healthz/
        //[HttpGet]
        //public ActionResult<bool> Get()
        //{
        //    return true;
        //}

        // GET api/healthz
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Ready", "Live" };
        }

        // GET api/healthz/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "healthy";
        }

        // POST api/healthz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/healthz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/healthz/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
