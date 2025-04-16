using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace JokesMCP;

[McpServerToolType]
public sealed class JokesTools
{
  private readonly JokesService jokesService;

  public JokesTools(JokesService jokesService)
  {
    this.jokesService = jokesService;
  }

  [McpServerTool, Description("Get a random Chuck Norris joke.")]
  public async Task<string> GetChuckNorrisJoke()
  {
    var joke = await jokesService.GetChuckNorrisJoke();
    return joke;
  }

  [McpServerTool, Description("Get a joke by category.")]
  public async Task<string> GetChuckNorrisJokeByCategory([Description("The category you want a joke of")] string category)
  {
    var joke = await jokesService.GetChuckNorrisJokeByCategory(category);
    return joke;
  }

  [McpServerTool, Description("Get all available categories.")]
  public async Task<string[]> GetChuckNorrisCategories()
  {
    var categories = await jokesService.GetChuckNorrisJokeCategories();
    return categories;
  }

  [McpServerTool, Description("Get a dad joke.")]
  public async Task<string> GetDadJoke()
  {
    var joke = await jokesService.GetDadJoke();
    return joke;
  }

  [McpServerTool, Description("Get a dad joke by ID.")]
  public async Task<string> GetDadJokeById([Description("The ID of the dad joke")] string id)
  {
    var joke = await jokesService.GetDadJokeById(id);
    return joke;
  }
}
