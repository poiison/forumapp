using AutoMapper;
using forumapp.entity.db;
using forumapp.entity.vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forumapp.webapi.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Mapper
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }


        public class DomainToViewModelMappingProfile : Profile
        {
            /// <summary>
            /// Config
            /// </summary>
            protected override void Configure()
            {
                CreateMap<dbCategory, CategoryDto>();
            }
        }

        public class ViewModelToDomainMappingProfile : Profile
        {
            /// <summary>
            /// Config
            /// </summary>
            protected override void Configure()
            {
                CreateMap<CategoryDto, dbCategory>();
            }
        }
    }
}