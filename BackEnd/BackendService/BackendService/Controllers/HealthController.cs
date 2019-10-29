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

        // GET api/health/
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return true;
        }

        //// GET: api/Health
        //[HttpGet]
        //public bool Get([FromHeader]string Host)
        //{

        //    return true;

        //    //if (Host != null)
        //    //{
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
            
        //}

        
        //public bool CheckHealth(string HealthProbe)
        //{
        //    String headerToCompare = "KubernetesHealthProbe";

        //    if ((HealthProbe != null) && (HealthProbe != String.Empty))
        //    {
        //        if (HealthProbe.ToLower().Equals(headerToCompare.ToLower()))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
