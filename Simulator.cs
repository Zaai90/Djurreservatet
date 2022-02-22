// See https://aka.ms/new-console-template for more information
internal class Simulator
{
    public int Leaves { get; set; }
    public int Meats { get; set; }
    public int Days { get; set; }

    private List<Animal> Animals { get; set; }

    public Simulator(int leaves, int meats, List<Animal> animals)
    {
        Leaves = leaves;
        Meats = meats;
        Animals = animals;
    }

    public void Run()
    {
        DateTime date = DateTime.Now;

        while (Leaves! > 0 && Meats! > 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Food supply levels:\nMeat: {Meats}\nLeaves: {Leaves}");
            Console.ResetColor();

            date = date.AddDays(1);
            Console.WriteLine($"It's day {Days}. A beautiful {date.DayOfWeek}.");
            AnimalLoop(CheckHunger);

            Thread.Sleep(100);
            AnimalLoop(IncreaseHunger);
            Days++;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTimes the animals were fed:");
        Console.ResetColor();
        AnimalLoop((animal) => Console.WriteLine($"{animal.Name} the {animal.GetType()} was fed {animal.TimesFed} times."));
        Console.WriteLine();
        AnimalLoop((animal) => Console.WriteLine($"{animal.Name} the {animal.GetType()} needs to be fed in: {(animal.HungerLimit - animal.CurrentHunger) + 1} days."));
        Console.WriteLine($"\nFood ran out after {Days - 1} days. You need to order more {(Leaves == 0 ? "leaves" : "meat")}!");
    }

    private void CheckHunger(Animal animal)
    {
        if (animal.IsHungry())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{animal.Name} the {animal.GetType()} is hungry and needs to eat!");
            Console.ResetColor();
            FeedAnimal(animal);
        }
    }
    private void FeedAnimal(Animal animal)
    {
        string givenfood = "";
        if (animal.EatsLeaf && animal.EatsMeat)
        {
            if (Leaves >= Meats)
            {
                givenfood = "leaves";
                Leaves--;
            }
            else
            {
                givenfood = "meat";
                Meats--;
            }
        }
        else if (animal.EatsLeaf)
        {
            givenfood = "leaves";
            Leaves--;
        }
        else if (animal.EatsMeat)
        {
            givenfood = "meat";
            Meats--;
        }
        Console.WriteLine($"{animal.Name} was fed with some delicious {givenfood}.");
        animal.Eat();

    }
    private void IncreaseHunger(Animal animal)
    {
        animal.IncreaseHunger();
    }


    private void AnimalLoop(Action<Animal> action)
    {
        foreach (var animal in Animals)
        {
            action?.Invoke(animal);
        }
    }
}