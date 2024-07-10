using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BackendChallenge.Movies.Dto;

namespace BackendChallenge.Movies;

public interface IMovieAppService : IAsyncCrudAppService<MovieDto, int, MovieListRequestDto, CreateUpdateMovieDto>
{
  Task<PagedResultDto<MovieDto>> GetPagedSortedMoviesAsync(MovieListRequestDto input);
}
