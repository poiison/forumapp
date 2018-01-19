using forumapp.business.irepositoy;
using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.repository.repository
{
    public class RepositoryPost : RepositoryBase<dbPost>, IRepositoryPost
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPostName()
        {
            return "Its working";
        }
    }
}
