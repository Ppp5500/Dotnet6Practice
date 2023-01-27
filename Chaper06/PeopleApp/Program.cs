﻿using static System.Console;
using Packt.Shared;

Person mike = new()
{
    Name = "Mike",
    DateOfBirth = DateTime.Now,
};

Person mary = new() { Name = "mary" };
Person jill = new() { Name = "Jill" };

// call instance methos
Person baby1 = mary.ProcreateWith(mike);
baby1.Name = "Gray";

// call static methos
Person baby2 = Person.Procreate(mary, jill);
// call an operator
Person baby3 = mike * jill;
WriteLine($"{mike.Name} has {mary.Children.Count} children");
WriteLine($"{mary.Name} has {mary.Children.Count} children");
WriteLine($"{jill.Name} has {mary.Children.Count} children");
WriteLine(
    format: "{0}'s first child is named \"{1}\".",
    arg0: mary.Name,
    arg1: mary.Children[0].Name);

WriteLine($"5! is {Person.Factorial(5)}");

static void Mike_Shout(object? sender, EventArgs e)
{
    if (sender is null) return;
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
}

mike.Shout = Mike_Shout;
mike.Poke();
mike.Poke();
mike.Poke();
mike.Poke();

System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: mike, value: "Delta");

int key = 2;
WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupObject[key]);

WriteLine(format: "Key {0} has value: {1}",
    arg0: mike,
    arg1: lookupObject[mike]);
// note: avoid types in the 'System.Collections' namespace

// Working with generic types

Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupIntString[key]);

// Implemention interfaces
Person[] people =
{
    new() { Name = "Simon"},
    new() { Name = "Jenny"},
    new() { Name = "Adam"},
    new() { Name = "Richard"}
};

WriteLine("Initial list of people:");
foreach(Person p in people)
{
    WriteLine($"    {p.Name}");
}

WriteLine("Use Person's IComparable implementation ot sort:");
Array.Sort(people);
foreach(Person p in people)
{
    WriteLine($"    {p.Name}");
}

WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach(Person p in people)
{
    WriteLine($"    {p.Name}");
}