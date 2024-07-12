using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace BackendChallenge.Movies.Dto;

public class CreateMovieDto
{
  public string Title { get; set; }
  public DateTime? ReleaseDate { get; set; }
  public string Overview { get; set; }
  public string PosterPath { get; set; }
  public decimal? Popularity { get; set; }
  public decimal? VoteAverage { get; set; }
  public int? VoteCount { get; set; }
  public bool? Adult { get; set; }
  public string OriginalLanguage { get; set; }
  public string OriginalTitle { get; set; }
  public string BackdropPath { get; set; }
  public bool? Video { get; set; }
  public string GenreIds { get; set; }
}
