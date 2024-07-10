using System.Net.Http;
using System.Threading.Tasks;
using Abp.Application.Services;
using BackendChallenge.Tmdb.Dtos;
using Newtonsoft.Json;

namespace BackendChallenge.Tmdb;

public class TmdbAppService : ApplicationService, ITmdbAppService
{
  private const string BaseUrl = "https://api.themoviedb.org/3/";
  private const string ApiKey = "12e409b5a2567665aa630163735e7915";
  private const string PopularMoviesEndpoint = "movie/popular";

  private readonly HttpClient _httpClient;

  public TmdbAppService(HttpClient httpClient)
  {
    _httpClient = httpClient;
    _httpClient.BaseAddress = new System.Uri(BaseUrl);
  }

  public async Task<ApiResponse> GetMoviesByPageAsync(int page)
  {
    string url = $"{PopularMoviesEndpoint}?api_key={ApiKey}&page={page}";

    HttpResponseMessage response = await _httpClient.GetAsync(url);

    if (response.IsSuccessStatusCode)
    {
      string content = await response.Content.ReadAsStringAsync();
      ApiResponse moviePage = JsonConvert.DeserializeObject<ApiResponse>(content);
      return moviePage;
    }
    else
    {
      throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
    }
  }
}
