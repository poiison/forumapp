using AutoMapper;
using forumapp.entity.db;
using forumapp.entity.dto;

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
                CreateMap<dbPost, PostDto>();
                CreateMap<dbUser, UserDto>();
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
                CreateMap<PostDto, dbPost>();
                CreateMap<UserDto, dbUser>();
            }
        }
    }
}