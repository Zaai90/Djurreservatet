public abstract class Herbivore : Animal
{
    public Herbivore()
    {
        base.EatsLeaf = true;
        base.EatsMeat = false;
    }
}