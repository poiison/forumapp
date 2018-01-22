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
        private readonly IRepositoryUser _userRepository;

        public BusinessPost(IRepositoryPost postRepository, IRepositoryUser userRepository) 
            : base(postRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        
        public async Task<ICollection<dbPost>> FindAllByLeader(int idCategory, int reply)
        {
            try
            {
                var lsTopics = _postRepository.FindAllByLeader(idCategory, reply).Result;

                foreach (var item in lsTopics)
                {
                    item.User = await _userRepository.FindById(item.IdUser);
                }
                
                return lsTopics;
            }
            catch (Exception) { throw; }
        }
    }
}
