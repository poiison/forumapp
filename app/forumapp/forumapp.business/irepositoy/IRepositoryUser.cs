using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.irepositoy
{
    public interface IRepositoryUser : IRepositoryBase<dbUser>
    {
        Task<dbUser> Login(dbUser user);
    }
}
