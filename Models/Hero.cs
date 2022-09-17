namespace dotnet6_simple_hero_api_example.Models
{
  public class Hero
  {
    public string Name {get; set; }
    public int Strength { get; set; }

    public Hero()
    {
      Name = "";
    }
  }
}
