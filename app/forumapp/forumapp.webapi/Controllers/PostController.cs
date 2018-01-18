using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace forumapp.webapi.Controllers
{
    [RoutePrefix("post")]
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("posts")]
        public async Task<IHttpActionResult> GetPosts()
        {
            return Ok();
        }
    }

}
