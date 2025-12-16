using AutoMapper;
using SimpleBlogMVC.Models;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PostAddViewModel, Post>();
        CreateMap<PostUpdateViewModel, Post>();

        CreateMap<TagAddViewModel, Tag>();
    }
}