public abstract class Carnivore : Animal
{
    public Carnivore()
    {
        base.EatsLeaf = false;
        base.EatsMeat = true;
    }
}