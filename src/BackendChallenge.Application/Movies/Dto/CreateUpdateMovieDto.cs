using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace BackendChallenge.Movies.Dto;

public class CreateUpdateMovieDto : EntityDto<int>
{
  public string Title { get; set; }

  public DateTime? ReleaseDate { get; set; }

  public string? Overview { get; set; }

  public bool? Adult { get; set; }

  public string? OriginalLanguage { get; set; }

  public string? OriginalTitle { get; set; }

  public List<int>? GenreIdsList { get; set; }
}
