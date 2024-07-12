// using System;
// using System.Threading.Tasks;
// using Abp.Dependency;
// using Abp.Domain.Repositories;
// using Abp.Domain.Uow;
// using Abp.Threading.BackgroundWorkers;
// using Abp.Threading.Timers;
// using AutoMapper;
// using BackendChallenge.Entities;
// using BackendChallenge.Tmdb;
// using BackendChallenge.Tmdb.Dtos;
// using Microsoft.Extensions.Logging;
//
// namespace BackendChallenge.Movies.Jobs;
//
// public class UpdateMovieDbWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
// {
//   private readonly IRepository<Movie> _movieRepository;
//   private readonly ITmdbAppService _tmdbAppService;
//   private readonly IUnitOfWorkManager _unitOfWorkManager;
//   private readonly IMapper _mapper;
//   private readonly ILogger<UpdateMovieDbWorker> _logger;
//
//   public UpdateMovieDbWorker(AbpAsyncTimer timer, IRepository<Movie> movieRepository,
//     ITmdbAppService tmdbAppService,
//     IUnitOfWorkManager unitOfWorkManager,
//     IMapper mapper,
//     ILogger<UpdateMovieDbWorker> logger)
//     : base(timer)
//   {
//     _movieRepository = movieRepository;
//     _tmdbAppService = tmdbAppService;
//     _unitOfWorkManager = unitOfWorkManager;
//     _mapper = mapper;
//     _logger = logger;
//
//     Timer.Period = (int)TimeSpan.FromHours(6).TotalMilliseconds;
//     Timer.RunOnStart = true;
//   }
//
//   [UnitOfWork]
//   protected override async Task DoWorkAsync()
//   {
//     using (IUnitOfWorkCompleteHandle unitOfWorkManager = _unitOfWorkManager.Begin())
//     {
//       try
//       {
//         int currentPage = 1;
//         int totalPages = 1;
//     
//         while (currentPage <= totalPages)
//         {
//           _logger.LogInformation($"Fetching movies from TMDB, page {currentPage}");
//           ApiResponse moviesData = await _tmdbAppService.GetMoviesByPageAsync(currentPage);
//           totalPages = moviesData.TotalPages;
//     
//           _logger.LogInformation($"Processing page {currentPage} of {totalPages}");
//     
//           foreach (Movie movie in moviesData.Results)
//           {
//             _logger.LogInformation($"Processing movie: {movie.Title}");
//     
//             Movie existingMovie = await _movieRepository.FirstOrDefaultAsync(m => m.Title == movie.Title);
//     
//             if (existingMovie == null)
//             {
//               _logger.LogInformation($"Inserting new movie: {movie.Title}");
//               movie.Id = 0;
//               await _movieRepository.InsertAsync(movie);
//             }
//             else
//             {
//               _logger.LogInformation($"Updating existing movie: {existingMovie.Title}");
//               _mapper.Map(movie, existingMovie);
//               await _movieRepository.UpdateAsync(existingMovie);
//             }
//     
//             _logger.LogInformation($"Saving changes for movie: {movie.Title}");
//             await CurrentUnitOfWork.SaveChangesAsync();
//           }
//     
//           currentPage++;
//         }
//     
//         await unitOfWorkManager.CompleteAsync();
//         _logger.LogInformation("Completed movie database update.");
//       }
//       catch (Exception e)
//       {
//         _logger.LogError(e, "An error occurred while updating the movie database.");
//         throw;
//       }
//     }
//   }
// }


