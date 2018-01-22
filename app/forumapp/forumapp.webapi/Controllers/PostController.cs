using AutoMapper;
using forumapp.business.ibusiness;
using forumapp.entity.db;
using forumapp.entity.dto;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostController : ApiController
    {
        private readonly IBusinessPost _postBusiness;

        public PostController(IBusinessPost postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [HttpGet]
        [Route("posts")]
        public async Task<IHttpActionResult> GetTopicPosts(int pid)
        {
            try
            {
                var result = await _postBusiness.FindAllByPost(pid);

                return Ok(Mapper.DynamicMap<IEnumerable<dbPost>, IEnumerable<PostDto>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("add")]
        [ValidateModelAttribute]
        public async Task<IHttpActionResult> PostAddPost(PostDto model)
        {
            try
            {
                var result = await _postBusiness.Insert(Mapper.DynamicMap<PostDto, dbPost>(model));

                return Ok(Mapper.DynamicMap<dbPost, PostDto>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            try
            {
                var result = await _postBusiness.Delete(id);

                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest("Sorry, I can't delete this data for you.");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

    }

}
