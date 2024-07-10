using System.Collections.Generic;
using BackendChallenge.Entities;
using Newtonsoft.Json;

namespace BackendChallenge.Tmdb.Dtos;

public class ApiResponse
{
  [JsonProperty("page")]
  public int Page { get; set; }

  [JsonProperty("total_results")]
  public int TotalResults { get; set; }

  [JsonProperty("total_pages")]
  public int TotalPages { get; set; }

  [JsonProperty("results")]
  public List<Movie> Results { get; set; }
}
