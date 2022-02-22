// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello and welcome to Jurassic World!");


List<Animal> list = new List<Animal>()
{
    new Elephant("Betty"),
    new Giraffe("Olle"),
    new Coyote("Gösta"),
    new Seal("Pelle"),
    new Bear("Kalle")
};


Simulator simulator = new Simulator(52, 56, list);
simulator.Run();