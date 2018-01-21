using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.entity.db
{
    public class dbPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int ÍdUser { get; set; }
    }
}
