// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello and welcome to Jurassic World!");

Simulator simulator = new Simulator(50, 50);
simulator.AddAnimal(new Giraffe("Olle"));
simulator.AddAnimal(new Elephant("Betty"));
simulator.AddAnimal(new Seal("Pelle"));
simulator.AddAnimal(new Coyote("Gösta"));
simulator.AddAnimal(new Bear("Kalle"));

Console.WriteLine("Simulation is running...");
simulator.Run();

Console.WriteLine("Done!");