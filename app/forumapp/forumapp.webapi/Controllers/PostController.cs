using forumapp.business.ibusiness;
using forumapp.webapi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace forumapp.webapi.Controllers
{
    [RoutePrefix("post")]
    //[AllowCors]
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
