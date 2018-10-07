using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _9_16SignalR.Controllers
{
    public class HomeApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult test()
        {
            return Ok("success");
        }
        [HttpPost]
        public IHttpActionResult checkAu()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok("Au");
            }
            else
            {
                return Ok("NoAu");
            }
            return Ok("success");
        }
    }
}
