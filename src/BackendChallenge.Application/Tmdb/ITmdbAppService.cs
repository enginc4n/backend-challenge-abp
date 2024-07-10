using System.Threading.Tasks;
using Abp.Application.Services;
using BackendChallenge.Tmdb.Dtos;

namespace BackendChallenge.Tmdb;

public interface ITmdbAppService : IApplicationService
{
  Task<ApiResponse> GetMoviesByPageAsync(int page);
}
