using forumapp.business.ibusiness;
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
        private readonly IBusinessPost _postBusiness;

        public PostController(IBusinessPost postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [HttpGet]
        [Route("getposts")]
        public async Task<IHttpActionResult> GetPosts()
        {
            var result = await _postBusiness.GetPostName();

            return Ok(result);
        }
    }

}
