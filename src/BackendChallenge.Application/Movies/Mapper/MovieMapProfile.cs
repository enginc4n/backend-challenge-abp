using AutoMapper;
using BackendChallenge.Entities;
using BackendChallenge.Movies.Dto;

namespace BackendChallenge.Movies.Mapper;

public class MovieMapProfile : Profile
{
  public MovieMapProfile()
  {
    CreateMap<Movie, MovieDt>().ReverseMap();
    CreateMap<CreateMovieDto, Movie>();
  }
}
