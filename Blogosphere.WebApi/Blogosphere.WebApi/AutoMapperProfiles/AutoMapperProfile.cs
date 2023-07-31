using AutoMapper;
using Blogosphere.WebApi.DTOs;
using Blogosphere.WebApi.Models;

namespace Blogosphere.WebApi.AutoMapperProfiles;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Blog, BlogDto>();
        CreateMap<CreateBlogDto, Blog>();
        CreateMap<CreateBlogDtoWithoutLarge, Blog>();
        CreateMap<UpdateBlogDto, Blog>();
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}
