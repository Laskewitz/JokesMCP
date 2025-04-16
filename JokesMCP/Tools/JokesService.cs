using System.Text.Json;

namespace JokesMCP;

public class JokesService
{
  private readonly HttpClient httpClient;

  public JokesService(IHttpClientFactory httpClientFactory)
  {
    httpClient = httpClientFactory.CreateClient();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
  }

  public async Task<string> GetChuckNorrisJoke()
  {
    var response = await httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
    if (response.IsSuccessStatusCode)
    {
      var joke = await response.Content.ReadAsStringAsync();
      return joke ?? "No joke found.";
    }
    return "No joke found.";
  }

  public async Task<string> GetChuckNorrisJokeByCategory(string category)
  {
    var response = await httpClient.GetAsync($"https://api.chucknorris.io/jokes/random?category={category}");
    if (response.IsSuccessStatusCode)
    {
      var joke = await response.Content.ReadAsStringAsync();
      return joke ?? "No joke found.";
    }
    return "No joke found.";
  }

  public async Task<string[]> GetChuckNorrisJokeCategories()
  {
    var response = await httpClient.GetAsync("https://api.chucknorris.io/jokes/categories");
    if (response.IsSuccessStatusCode)
    {
      var categories = await response.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<string[]>(categories) ?? Array.Empty<string>();
    }
    return Array.Empty<string>();
  }

  public async Task<string> GetDadJoke()
  {
    var response = await httpClient.GetAsync("https://icanhazdadjoke.com/");
    if (response.IsSuccessStatusCode)
    {
      var joke = await response.Content.ReadAsStringAsync();
      return joke ?? "No joke found.";
    }
    return "No joke found.";
  }

  public async Task<string> GetDadJokeById(string id)
  {
    var response = await httpClient.GetAsync($"https://icanhazdadjoke.com/j/{id}");
    if (response.IsSuccessStatusCode)
    {
      var joke = await response.Content.ReadAsStringAsync();
      return joke ?? "No joke found.";
    }
    return "No joke found.";
  }
}
