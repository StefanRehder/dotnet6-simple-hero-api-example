using dotnet6_simple_hero_api_example.Models;
using System.Collections;

namespace dotnet6_simple_hero_api_example.Data
{
  // In memory data used for this example
  // It could be replaced by a database or a file
  class HeroCollection
  {
    private Hashtable heroes = new Hashtable();

    public HeroCollection()
    {
      // Always start app with these heroes
      AddHero(new Hero
      {
        Name = "Super Woman",
        Strength = 7
      });
      AddHero(new Hero
      {
        Name = "Batman",
        Strength = 6
      });
      AddHero(new Hero
      {
        Name = "Superman",
        Strength = 10
      });
      AddHero(new Hero
      {
        Name = "Robin",
        Strength = 1
      });
    }

    public void AddHero(Hero hero)
    {
      if (heroes.ContainsKey(hero.Name))
        throw new Exception("Hero already exists!");

      heroes.Add(hero.Name, hero);
    }

    public Hero? GetHero(string name)
    {
      if (!heroes.ContainsKey(name))
        throw new Exception("Hero does not exist!");

      return heroes[name] as Hero;
    }

    public void PutHero(Hero hero)
    {
      if (!heroes.ContainsKey(hero.Name))
        throw new Exception("Hero does not exist! Create a new hero instead.");

      DeleteHero(hero.Name);
      AddHero(hero);
    }

    public void PostHero(Hero hero)
    {
      if (heroes.ContainsKey(hero.Name))
        throw new Exception("Hero already exists! Edit existing hero instead.");
      
      AddHero(hero);
    }

    public void DeleteHero(string name)
    {
      if (!heroes.ContainsKey(name))
        throw new Exception("Hero does not exist!");

      heroes.Remove(name);
    }

    public Hero[] GetHeroes()
    {
      Hero[] heroArr = new Hero[heroes.Count];
      heroes.Values.CopyTo(heroArr, 0);
      return heroArr;
    }
  }
}
