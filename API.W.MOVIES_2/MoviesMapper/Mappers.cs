using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using AutoMapper;

namespace API.W.MOVIES_2.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
        }
    }
}
