public abstract class Omnivore : Animal
{
    public Omnivore()
    {
        base.EatsLeaf = true;
        base.EatsMeat = true;
    }
}