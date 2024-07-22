using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using BackendChallenge.Entities;
using BackendChallenge.Movies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Movies;

[Route("api/movie")]
public class MovieAppService : ApplicationService, IMovieAppService
{
  private readonly IRepository<Movie> _movieRepository;

  public MovieAppService(IRepository<Movie> movieRepository)
  {
    _movieRepository = movieRepository;
  }

  [HttpPost("create")]
  public async Task<MovieDt> CreateMovie(CreateMovieDto input)
  {
    Movie createdMovie = ObjectMapper.Map<Movie>(input);
    await _movieRepository.InsertAsync(createdMovie);
    await CurrentUnitOfWork.SaveChangesAsync();
    return ObjectMapper.Map<MovieDt>(createdMovie);
  }
  
  [HttpPost("getbyid/{id}")]
  public async Task<MovieDt> GetMovieById(int id)
  {
    Movie requestedMovie = await _movieRepository.GetAsync(id);
    return null;
  }

  [HttpPost("getbyid/{id}")]
  public async Task<MovieDto> GetMovieById(int id)
  {
    Movie requestedMovie = await _movieRepository.GetAsync(id);
    return null;
  }
}
