using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BackendChallenge.Entities;
using BackendChallenge.Movies.Dto;

namespace BackendChallenge.Movies;

public class MovieAppService : AsyncCrudAppService<Movie, MovieDto, int, MovieListRequestDto, CreateUpdateMovieDto>, IMovieAppService
{
  public MovieAppService(IRepository<Movie, int> repository) : base(repository)
  {
  }

  public async Task<PagedResultDto<MovieDto>> GetPagedSortedMoviesAsync(MovieListRequestDto input)
  {
    IQueryable<Movie> query = Repository.GetAll();
    query = ApplySorting(query, input);
    int totalCount = await AsyncQueryableExecuter.CountAsync(query);
    query = ApplyPaging(query, input);
    List<Movie> movies = await AsyncQueryableExecuter.ToListAsync(query);
    return new PagedResultDto<MovieDto>(totalCount, ObjectMapper.Map<List<MovieDto>>(movies));
  }
}
