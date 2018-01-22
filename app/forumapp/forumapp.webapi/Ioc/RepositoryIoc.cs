using forumapp.business.irepositoy;
using forumapp.repository.repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forumapp.webapi.Ioc
{
    public class RepositoryIoc
    {
        /// <summary>
        /// Iocs registry
        /// </summary>
        /// <param name="kernel"></param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IRepositoryPost>().To<RepositoryPost>();
            kernel.Bind<IRepositoryCategory>().To<RepositoryCategory>();
            kernel.Bind<IRepositoryUser>().To<RepositoryUser>();
        }
    }
}