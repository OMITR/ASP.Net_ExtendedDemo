using AutoMapper;
using MoviesApp.Models;

namespace MoviesApp.Service.DTO.Mappers
{
    public class ActorDTOProfile : Profile
    {
        public ActorDTOProfile()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}
