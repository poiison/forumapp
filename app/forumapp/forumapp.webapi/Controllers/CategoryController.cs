using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace forumapp.webapi.Controllers
{
    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
       
        [HttpGet]
        [Route("categories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            return Ok();
        }


    }
}
