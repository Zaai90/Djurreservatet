// See https://aka.ms/new-console-template for more information
public class Simulator
{
    public int Leaves { get; set; }
    public int Meats { get; set; }
    public int Days { get; set; } = 0;

    private const string directory = "logs/";
    private string logPath = "";
    private List<Animal> Animals { get; set; } = new();

    public Simulator(int leaves, int meats)
    {
        System.IO.Directory.CreateDirectory(directory);
        Leaves = leaves;
        Meats = meats;
    }

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public void Run()
    {
        logPath = $"{directory}log_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.txt";
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
            File.AppendAllText(logPath, FeedAnimal(animal) ? "" : $"\n{animal.Name} the {animal.GetType()} could not be fed because food was finished!");
        }
    }
    private bool FeedAnimal(Animal animal)
    {
        bool meatFin = Meats == 0;
        bool leafFin = Leaves == 0;

        string givenfood = "";

        if (animal.EatsLeaf && animal.EatsMeat)
        {
            if (Leaves <= Meats && !meatFin)
            {
                givenfood = "meat";
                Meats--;
            }
            else if (!leafFin)
            {
                givenfood = "leaves";
                Leaves--;
            }
            else
            {
                return false;
            }
        }
        else if (animal.EatsLeaf)
        {
            if (!leafFin)
            {
                givenfood = "leaves";
                Leaves--;
            }
            else
            {
                return false;
            }
        }
        else if (animal.EatsMeat)
        {
            if (!meatFin)
            {
                givenfood = "meat";
                Meats--;
            }
            else
            {
                return false;
            }
        }
        File.AppendAllText(logPath, $"\n{animal.Name} was fed with some delicious {givenfood}.");
        animal.Eat();
        return true;
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