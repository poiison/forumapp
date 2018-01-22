using forumapp.business.ibusiness;
using forumapp.business.irepositoy;
using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace forumapp.business.services
{
    public class BusinessCategory : BusinessBase<dbCategory>, IBusinessCategory
    {
        private readonly IRepositoryCategory _categoryRepository;
        private readonly IRepositoryPost _postRepository;

        public BusinessCategory(IRepositoryCategory categoryRepository, IRepositoryPost postRepository) 
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
        }

        /// <summary>
        /// Return all objects
        /// </summary>
        /// <returns></returns>
        public override async Task<ICollection<dbCategory>> FindAll()
        {
            try
            {
                var lsCategories = _categoryRepository.FindAll().Result;

                foreach (var item in lsCategories)
                {
                    var result = _postRepository.FindAllByLeader(item.Id, 0).Result;

                    item.TotalTopics = result.Count;
                }

                return lsCategories;
            }
            catch (Exception) { throw; }
        }
    }
}
