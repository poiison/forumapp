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
        public int Reply { get; set; }

        public int IdCategory { get; set; }
        public int IdUser { get; set; }
        public dbUser User { get; set; }
    }
}
