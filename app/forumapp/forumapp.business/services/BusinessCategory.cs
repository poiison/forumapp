using forumapp.business.ibusiness;
using forumapp.business.irepositoy;
using forumapp.entity.db;

namespace forumapp.business.services
{
    public class BusinessCategory : BusinessBase<dbCategory>, IBusinessCategory
    {
        private readonly IRepositoryCategory _categoryRepository;

        public BusinessCategory(IRepositoryCategory categoryRepository) 
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

    }
}
