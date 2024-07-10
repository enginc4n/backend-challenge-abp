using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using BackendChallenge.Entities;
using BackendChallenge.Tmdb;
using BackendChallenge.Tmdb.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BackendChallenge.Movies.Jobs;

public class UpdateMovieDbWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
{
  private readonly IRepository<Movie> _movieReposityory;
  private readonly ITmdbAppService _tmdbAppService;

  public UpdateMovieDbWorker(AbpAsyncTimer timer, IRepository<Movie> movieReposityory, ITmdbAppService tmdbAppService) : base(timer)
  {
    _movieReposityory = movieReposityory;
    _tmdbAppService = tmdbAppService;
    Timer.Period = (int)TimeSpan.FromHours(6).TotalMilliseconds;
  }

  protected override async Task DoWorkAsync()
  {
    int currentPage = 1;
    int totalPages = 1;
    while (currentPage <= totalPages)
    {
      try
      {
        ApiResponse moviesData = await _tmdbAppService.GetMoviesByPageAsync(currentPage);
        totalPages = moviesData.TotalPages;
        foreach (Movie movie in moviesData.Results)
        {
          await _movieReposityory.InsertOrUpdateAsync(movie);
        }

        currentPage++;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}
