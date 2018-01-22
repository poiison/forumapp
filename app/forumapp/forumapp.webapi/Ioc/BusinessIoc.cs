using forumapp.business.ibusiness;
using forumapp.business.services;
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
            kernel.Bind(typeof(IBusinessBase<>)).To(typeof(BusinessBase<>));
            kernel.Bind<IBusinessPost>().To<BusinessPost>();
            kernel.Bind<IBusinessCategory>().To<BusinessCategory>();
            kernel.Bind<IBusinessUser>().To<BusinessUser>();
        }
    }
}