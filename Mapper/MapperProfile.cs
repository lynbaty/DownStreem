using AutoMapper;
using downstreem.Dtos;
using downstreem.Models;

namespace downstreem.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserSignUpDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<EntityCreateDTO, Entity>().ReverseMap();
            CreateMap<EntityEditDTO, Entity>().ReverseMap();
        }
    }
}
