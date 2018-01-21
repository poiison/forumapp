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
    public class BusinessUser : BusinessBase<dbUser>, IBusinessUser
    {
        private readonly IRepositoryUser _userRepository;

        public BusinessUser(IRepositoryUser userRepository) 
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<dbUser> Login(dbUser user)
        {
            try
            {
                return _userRepository.Login(user).Result;
            }
            catch (Exception e) { throw; }
        }
    }
}
