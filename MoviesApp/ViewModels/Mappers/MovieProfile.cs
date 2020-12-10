using AutoMapper;
using MoviesApp.Models;
using MoviesApp.Service.DTO.Mappers;

namespace MoviesApp.ViewModels.Mappers
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, InputMovieViewModel>().ReverseMap();
            CreateMap<Movie, DeleteMovieViewModel>();
            CreateMap<Movie, EditMovieViewModel>().ReverseMap();
            CreateMap<Movie, MovieViewModel>();

            CreateMap<ActorDto, InputActorViewModel>().ReverseMap();
            CreateMap<ActorDto, DeleteActorViewModel>(); ;
            CreateMap<ActorDto, EditActorViewModel>().ReverseMap();
            CreateMap<ActorDto, ActorViewModel>();
        }
    }
}
