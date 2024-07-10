using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using BackendChallenge.Controllers;
using BackendChallenge.Movies;
using BackendChallenge.Movies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Web.Host.Controllers
{
  [Route("api/movies")]
  public class MoviesController : BackendChallengeControllerBase
  {
    private readonly IMovieAppService _movieAppService;

    public MoviesController(IMovieAppService movieAppService)
    {
      _movieAppService = movieAppService;
    }

    [HttpGet("getpagedmovies")]
    public async Task<IActionResult> GetPagedSortedMovies([FromQuery] MovieListRequestDto input)
    {
      PagedResultDto<MovieDto> movies = await _movieAppService.GetPagedSortedMoviesAsync(input);
      return Ok(movies);
    }
  }
}
