using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using BackendChallenge.Entities;
using BackendChallenge.Tmdb;
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
    Timer.Period = 60000;
  }

  protected override Task DoWorkAsync()
  {
    _tmdbAppService.GetMoviesByPageAsync()
  }
}
