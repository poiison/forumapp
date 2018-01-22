﻿using AutoMapper;
using forumapp.business.ibusiness;
using forumapp.entity.db;
using forumapp.entity.dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace forumapp.webapi.Controllers
{
    [RoutePrefix("topic")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TopicController : ApiController
    {
        private readonly IBusinessPost _postBusiness;

        public TopicController(IBusinessPost postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [HttpGet]
        [Route("topics")]
        public async Task<IHttpActionResult> GetTopicPosts(int category)
        {
            try
            {
                var result = await _postBusiness.FindAllByLeader(category, 0);

                return Ok(Mapper.DynamicMap<IEnumerable<dbPost>, IEnumerable<PostDto>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
