using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using AutoMapper;
using System.Runtime;

namespace API.W.MOVIES_2.MoviesMapper
{
    public class Mapper : Profile
    {
        protected Mapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
