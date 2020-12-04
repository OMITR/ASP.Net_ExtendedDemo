using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

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

            CreateMap<Actor, InputActorViewModel>().ReverseMap();
            CreateMap<Actor, DeleteActorViewModel>().ReverseMap();
            CreateMap<Actor, EditActorViewModel>().ReverseMap();
            CreateMap<Actor, ActorViewModel>().ReverseMap();
        }
    }
}
