// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello and welcome to Jurassic World!");


List<Animal> list = new List<Animal>()
{
    new Giraffe("Olle"),
    new Elephant("Betty"),
    new Seal("Pelle"),
    new Coyote("Gösta"),
    new Bear("Kalle")
};


Simulator simulator = new Simulator(25, 30, list);
simulator.Run();