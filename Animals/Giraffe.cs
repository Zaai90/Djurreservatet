public class Giraffe : Herbivore
{
    public Giraffe(string name)
    {
        base.Name = name;
        base.HungerLimit = 7;
    }
}