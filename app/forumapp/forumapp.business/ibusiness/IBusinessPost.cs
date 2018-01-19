using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.ibusiness
{
    public interface IBusinessPost : IBusinessBase<dbPost>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<string> GetPostName();
    }
}
