// See https://aka.ms/new-console-template for more information
public class Simulator
{
    public int Leaves { get; set; }
    public int Meats { get; set; }
    public int Days { get; set; } = 0;

    public string logPath = @"logs/";
    private List<Animal> Animals { get; set; } = new();

    public Simulator(int leaves, int meats)
    {
        System.IO.Directory.CreateDirectory("logs/");
        Leaves = leaves;
        Meats = meats;
    }

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public void Run()
    {
        logPath += $"log_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.txt";
        File.AppendAllText(logPath, $"Simulation at {DateTime.Now} - Started:");
        DateTime date = DateTime.Now;

        while (Leaves! > 0 || Meats! > 0)
        {
            File.AppendAllText(logPath, $"\nFood supply levels:\nMeat: {Meats}\nLeaves: {Leaves}");

            date = date.AddDays(1);
            File.AppendAllText(logPath, $"\n\nIt's day {Days}. A beautiful {date.DayOfWeek}.");
            AnimalLoop(CheckHunger);

            Thread.Sleep(10);
            AnimalLoop(IncreaseHunger);
            Days++;
        }


        File.AppendAllText(logPath, "\n\nTimes the animals were fed:");
        AnimalLoop((animal) => File.AppendAllText(logPath, $"\n{animal.Name} the {animal.GetType()} was fed {animal.TimesFed} times."));
        File.AppendAllText(logPath, "\n");
        AnimalLoop((animal) => File.AppendAllText(logPath, $"\n{animal.Name} the {animal.GetType()} needs to be fed in: {(animal.HungerLimit - animal.CurrentHunger) + 1} days."));
        File.AppendAllText(logPath, $"\nFood ran out after {Days - 1} days. You need to order more {(Leaves >= 0 && Meats <= 0 ? "of both leaves and meat" : Leaves <= 0 ? "leaves" : "meat")}!");
        File.AppendAllText(logPath, "\n\n---------------------...Simulation ended...------------------------\n");
    }

    private void CheckHunger(Animal animal)
    {
        if (animal.IsHungry())
        {
            File.AppendAllText(logPath, $"\n{animal.Name} the {animal.GetType()} is hungry and needs to eat!");
            FeedAnimal(animal);
        }
    }
    private void FeedAnimal(Animal animal)
    {
        string givenfood = "";
        if (animal.EatsLeaf && animal.EatsMeat)
        {
            if (Leaves <= Meats)
            {
                givenfood = "meat";
                Meats--;
            }
            else
            {
                givenfood = "leaves";
                Leaves--;
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
        File.AppendAllText(logPath, $"\n{animal.Name} was fed with some delicious {givenfood}.");
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