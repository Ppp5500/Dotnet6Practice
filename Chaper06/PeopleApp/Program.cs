using static System.Console;
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
baby1.Name = "Gary";

// call static methos
Person baby2 = Person.Procreate(mary, jill);
WriteLine($"{mike.Name} has {mary.Children.Count} children");
WriteLine($"{mary.Name} has {mary.Children.Count} children");
WriteLine($"{jill.Name} has {mary.Children.Count} children");
WriteLine(
    format: "{0}'s first child is named \"{1}\".",
    arg0: mary.Name,
    arg1: mary.Children[0].Name);