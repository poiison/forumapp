using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.ibusiness
{
    public interface IBusinessUser : IBusinessBase<dbUser>
    {
        Task<dbUser> Login(dbUser user);
    }
}
