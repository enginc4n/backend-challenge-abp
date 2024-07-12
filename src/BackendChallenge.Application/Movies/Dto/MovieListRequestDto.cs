using Abp.Application.Services.Dto;

namespace BackendChallenge.Movies.Dto;

public class MovieListRequestDto : PagedAndSortedResultRequestDto
{
  public string Filter { get; set; }
}
