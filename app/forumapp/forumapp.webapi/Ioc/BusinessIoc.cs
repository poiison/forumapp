using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forumapp.webapi.Ioc
{
    public class BusinessIoc
    {
        /// <summary>
        /// Iocs registry
        /// </summary>
        /// <param name="kernel"></param>
        public static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            //kernel.Bind<IRepositorioModelo>().To<RepositorioModelo>();

             
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
        }
    }
}