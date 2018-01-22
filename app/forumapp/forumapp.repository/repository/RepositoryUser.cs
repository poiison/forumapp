using forumapp.business.irepositoy;
using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.repository.repository
{
    public class RepositoryUser : RepositoryBase<dbUser>, IRepositoryUser
    {
        private static List<dbUser> lsUser = new List<dbUser>();

        public RepositoryUser()
        {
            if (lsUser.Count == 0)
            {
                lsUser.Add(new dbUser() { Id = 1, Username = "user1", Password = "user1" });
                lsUser.Add(new dbUser() { Id = 2, Username = "user2", Password = "user2" });
            }
        }

        /// <summary>
        /// Find by Id
        /// </summary>
        /// <returns></returns>
        public override async Task<dbUser> FindById(int id)
        {
            try
            {
                return await Task.FromResult(lsUser.Where(x=>x.Id == id).FirstOrDefault());
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<dbUser> Login(dbUser user)
        {
            try
            {
                var userdb = lsUser.Where(x => x.Username == user.Username).FirstOrDefault();

                if (userdb != null)
                {
                    if (userdb.Password == user.Password)
                        return userdb;
                    return null;
                }
                else
                    return null;
            }
            catch (Exception) { throw; }
        }
    }
}
