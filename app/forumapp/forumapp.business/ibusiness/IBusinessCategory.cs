using forumapp.entity.db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace forumapp.business.ibusiness
{
    public interface IBusinessCategory :  IBusinessBase<dbCategory>
    {
        Task<ICollection<dbCategory>> FindAll();
    }
}
