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
        private static List<dbPost> lsPost = new List<dbPost>();

        public RepositoryPost()
        {
            if (lsPost.Count == 0)
            {
                lsPost.Add(new dbPost() { Id = 1, Title = "My Title For Development 1", Comment = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ultricies posuere elit, id vulputate ligula ullamcorper sit amet. Proin varius enim libero, eget hendrerit sem dictum elementum. Vestibulum iaculis lectus id purus pharetra tristique. Donec facilisis, elit quis suscipit dapibus, orci tellus ullamcorper enim, sed ullamcorper nulla odio et ante. Suspendisse ut condimentum sapien, nec molestie diam. Curabitur nec orci sit amet risus aliquet varius sed non enim. Curabitur posuere leo non arcu pretium aliquam. Aenean non commodo magna, nec finibus tortor. Nulla accumsan ullamcorper massa. Aliquam efficitur consequat sem quis maximus. Interdum et malesuada fames ac ante ipsum primis in faucibus.", IdUser = 1, IdCategory = 1, Reply = 0 });
                lsPost.Add(new dbPost() { Id = 2, Title = "My Title For Development 2", Comment = @"Nullam turpis ex, accumsan in molestie in, aliquam sit amet lorem. Phasellus facilisis velit risus, eu pretium odio accumsan ac. Maecenas pulvinar pellentesque leo a tristique. Etiam ullamcorper orci sit amet tellus feugiat facilisis. Quisque et cursus sem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur non libero eu nibh convallis condimentum non eget velit. Integer eu fermentum magna. Maecenas posuere lectus quis erat tempus, sed maximus felis elementum. Mauris elementum gravida ipsum sit amet auctor.", IdUser = 2, IdCategory = 1 , Reply = 1 });
                lsPost.Add(new dbPost() { Id = 3, Title = "My Title For Database", Comment = @"Curabitur egestas mattis lectus, eu mollis orci. Integer euismod arcu nisl, mattis luctus quam imperdiet in. Morbi eget sapien leo. Aliquam a nunc ac lectus accumsan maximus. Morbi sagittis, massa eu pretium tincidunt, velit odio accumsan massa, nec lacinia massa dui quis orci. Fusce libero nulla, eleifend vel sapien porta, luctus sollicitudin sem. Integer accumsan sagittis mauris vel auctor. Sed imperdiet vehicula felis non auctor. Etiam sed condimentum sem, sed egestas nunc.", IdUser = 1, IdCategory = 2, Reply = 0 });
            }
        }

        //public override async Task<ICollection<dbPost>> FindAll(int category)
        //{
        //    try
        //    {
        //        return await Task.FromResult(lsPost.Where(x=>x.IdCategory == category && x.Reply == 0).ToList());
        //    }
        //    catch (Exception) { throw; }
        //}

        public async Task<ICollection<dbPost>> FindAllByLeader(int idCategory, int reply)
        {
            try
            {
                return await Task.FromResult(lsPost.Where(x=>x.IdCategory == idCategory && x.Reply == reply).ToList());
            }
            catch (Exception) { throw; }
        }
    }
}
