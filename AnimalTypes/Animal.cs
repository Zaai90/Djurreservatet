public abstract class Animal
{
    public string Name { get; protected set; }
    public bool EatsMeat { get; protected set; }
    public bool EatsLeaf { get; protected set; }
    public byte HungerLimit { get; protected set; }
    public byte CurrentHunger { get; protected set; } = 0;
    public int TimesFed { get; protected set; } = 0;

    public void Eat()
    {
        CurrentHunger = 0;
        TimesFed++;
    }

    public bool IsHungry()
    {
        return CurrentHunger == HungerLimit;
    }

    public void IncreaseHunger()
    {
        CurrentHunger++;
    }

}