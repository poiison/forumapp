using forumapp.business.irepositoy;
using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forumapp.repository.repository
{
    public class RepositoryCategory : RepositoryBase<dbCategory>, IRepositoryCategory
    {
        private static List<dbCategory> lsCategory = new List<dbCategory>();

        public RepositoryCategory()
        {
            if (lsCategory.Count == 0)
            {
                lsCategory.Add(new dbCategory() { Id = 1, Name = "Development", Description = "Something" , IdUserCreated= 1});
                lsCategory.Add(new dbCategory() { Id = 2, Name = "Database", Description = "Something more", IdUserCreated = 1 });
                lsCategory.Add(new dbCategory() { Id = 3, Name = "Scripts", Description = "Something less", IdUserCreated = 2 });
            }
        }

        /// <summary>
        ///  Return all objects
        /// </summary>
        /// <returns></returns>
        public override async Task<ICollection<dbCategory>> FindAll()
        {
            try
            {
                return await Task.FromResult(lsCategory.ToList());
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Insert new object
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override async Task<dbCategory> Insert(dbCategory item)
        {
            try
            {
                item.Id = lsCategory.Count + 1;

                lsCategory.Add(item);

                return item;

            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<int> Delete(int id)
        {
            try
            {
                var existe = lsCategory.Where(x => x.Id == id).FirstOrDefault();

                if (existe != null)
                {
                    lsCategory.RemoveAll(x => x.Id == id);

                    return 1;
                }

                return 0;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Find by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<dbCategory> FindById(int id)
        {
            try
            {
                return await Task.FromResult(lsCategory.Where(x => x.Id == id).FirstOrDefault());
            }
            catch (Exception) { throw; }
        }

    }
}
