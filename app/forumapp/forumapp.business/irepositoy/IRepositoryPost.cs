﻿using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.irepositoy
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepositoryPost : IRepositoryBase<dbPost>
    {
        Task<ICollection<dbPost>> FindAllByLeader(int idCategory, int reply);

        Task<ICollection<dbPost>> FindAllByPost(int post);
    }
}
