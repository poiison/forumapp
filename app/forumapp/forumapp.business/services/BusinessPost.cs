using forumapp.business.ibusiness;
using forumapp.business.irepositoy;
using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.services
{
    public class BusinessPost : BusinessBase<dbPost>, IBusinessPost
    {
        private readonly IRepositoryPost _postRepository;

        public BusinessPost(IRepositoryPost postRepository) 
            : base(postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPostName()
        {
            try
            {
                return _postRepository.GetPostName().Result;
            }
            catch (Exception e) { throw; }
        }
    }
}
