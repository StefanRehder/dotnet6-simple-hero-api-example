using Microsoft.AspNetCore.Mvc;
using dotnet6_simple_hero_api_example.Data;
using dotnet6_simple_hero_api_example.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace dotnet6_simple_hero_api_example.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HeroesController : ControllerBase
  {
    private static readonly HeroCollection heroes = new HeroCollection();

    [HttpGet]
    [SwaggerOperation(Summary = "Get all heroes synchronously.")]
    [SwaggerResponse(200, "Everything is OK.")]
    [SwaggerResponse(500, "Something went wrong.")]
    public ActionResult<IEnumerable<Hero>> GetHeroes()
    {
      try
      {
        return Ok(heroes.GetHeroes());
      }
      catch (Exception e)
      {
        return StatusCode(500, e.Message);
      }
    }

    [HttpGet("{name}")]
    [SwaggerOperation(Summary = "Get a specific hero.")]
    [SwaggerResponse(200, "Everything is OK.")]
    [SwaggerResponse(404, "Hero was not found.")]
    public ActionResult<Hero> GetHero(string name)
    {
      try 
      {
        var hero = heroes.GetHero(name);
        return Ok(hero);
      } 
      catch (Exception e) 
      {
        return NotFound(e.Message);
      }
    }

    [HttpPost()]
    [SwaggerOperation(Summary = "Create a new hero.")]
    [SwaggerResponse(201, "Everything is OK.")]
    [SwaggerResponse(400, "Bad Request. The request body could not be parsed as a Hero.")]
    [SwaggerResponse(409, "Hero already exist.")]
    public ActionResult CreateNewHero([FromBody] Hero hero)
    {
      if (hero == null)
        return BadRequest();

      try
      {
        heroes.PostHero(hero);
        return Created(String.Format("/api/Heroes/{0}",hero.Name), hero);
      }
      catch (Exception e)
      {
        return Conflict(e.Message);
      }
    }

    [HttpPut()]
    [SwaggerOperation(Summary = "Update existing hero.")]
    [SwaggerResponse(200, "Everything is OK.")]
    [SwaggerResponse(400, "Bad Request. The request body could not be parsed as a Hero.")]
    [SwaggerResponse(404, "Hero was not found.")]
    public ActionResult UpdateHero([FromBody] Hero hero)
    {
      if (hero == null)
        return BadRequest();

      try
      {
        heroes.PutHero(hero);
        return Ok();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpDelete("{name}")]
    [SwaggerOperation(Summary = "Delete existing hero.")]
    [SwaggerResponse(200, "Everything is OK.")]
    [SwaggerResponse(400, "Bad Request. The name parameter was empty.")]
    [SwaggerResponse(404, "Hero was not found.")]
    public ActionResult DeleteHero(string name)
    {
      if (String.IsNullOrEmpty(name))
        return BadRequest();

      try
      {
        heroes.DeleteHero(name);
        return Ok();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

    // Example Async call - Imagine awaiting a call to a database instead of this memory fetch
    [HttpGet("Async")]
    [SwaggerOperation(Summary = "Get all heroes asynchronously.")]
    public async IAsyncEnumerable<Hero> GetHeroesAsync()
    {
      foreach (var hero in await Task.Run(() => heroes.GetHeroes()))
      {
        yield return hero;
      }
    }
  }
}
