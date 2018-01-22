using AutoMapper;
using forumapp.business.ibusiness;
using forumapp.entity.db;
using forumapp.entity.dto;
using forumapp.webapi.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace forumapp.webapi.Controllers
{
    [RoutePrefix("category")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private readonly IBusinessCategory _categoryBusiness;

        public CategoryController(IBusinessCategory categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            try
            {
                var result = await _categoryBusiness.FindAll();

                return Ok(Mapper.DynamicMap<IEnumerable<dbCategory>, IEnumerable<CategoryDto>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        [Route("category")]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            try
            {
                var result = await _categoryBusiness.FindById(id);

                return Ok(Mapper.DynamicMap<dbCategory, CategoryDto>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [HttpPost]
        [Route("add")]
        [ValidateModelAttribute]
        public async Task<IHttpActionResult> PostAddCategories(CategoryDto model)
        {
            try
            {
                var result = await _categoryBusiness.Insert(Mapper.DynamicMap<CategoryDto, dbCategory>(model));

                return Ok(Mapper.DynamicMap<dbCategory, CategoryDto>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteCategories(int id)
        {
            try
            {
                var result = await _categoryBusiness.Delete(id);

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
