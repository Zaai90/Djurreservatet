public class Bear : Omnivore
{
    public Bear(string name)
    {
        base.Name = name;
        base.HungerLimit = 3;
    }
}