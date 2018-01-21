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
    [RoutePrefix("account")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private readonly IBusinessUser _userBusiness;

        public AccountController(IBusinessUser userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("login")]
        [ValidateModelAttribute]
        public async Task<IHttpActionResult> PostLogin(UserDto user)
        {
            try
            {
                var result = await _userBusiness.Login(Mapper.DynamicMap<UserDto, dbUser>(user));

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
