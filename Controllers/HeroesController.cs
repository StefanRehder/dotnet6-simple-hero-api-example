using Microsoft.AspNetCore.Mvc;
using dotnet6_simple_hero_api_example.Data;
using dotnet6_simple_hero_api_example.Models;

namespace dotnet6_simple_hero_api_example.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HeroesController : ControllerBase
  {
    private static HeroCollection heroes = new HeroCollection();

    [HttpGet]
    public IEnumerable<Hero> GetHeroes()
    {
      return heroes.GetHeroes();
    }

    [HttpGet("{name}")]
    public ActionResult<Hero> GetHero(string name)
    {
      var hero = heroes.GetHero(name);
      if (hero == null)
        return NotFound();
      else 
        return Ok(hero);
    }

    [HttpPut()]
    public ActionResult PutHero([FromBody] Hero hero)
    {
      if (hero == null)
        return BadRequest();
      else
      {
        heroes.PutHero(hero); 
        return Ok();
      }
    }

    [HttpDelete("{name}")]
    public ActionResult DeleteHero(string name)
    {
      if (String.IsNullOrEmpty(name))
        return BadRequest();
      else
      {
        heroes.DeleteHero(name);
        return Ok();
      }
    }

    [HttpGet("Async")]
    public async IAsyncEnumerable<Hero> GetHeroesAsync()
    {
      foreach (var hero in await Task.Run(() => heroes.GetHeroes()))
      {
        yield return hero;
      }
    }
  }
}
