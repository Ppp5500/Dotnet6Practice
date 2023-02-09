// create an object graph
using Packt.Shared;
using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;
using static System.Console;
using NewJson = System.Text.Json.JsonSerializer;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;

List<Person> people = new()
{
    new()
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(1974, 3, 14)
    },
    new()
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1969, 11, 23)
    },
    new()
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(1984, 5, 4),
        Children = new()
        {
            new()
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(2000, 7, 12),
            }
        }
    }
};

// create object that will format a List of Persons as XML
XmlSerializer xs = new(people.GetType());
// create a file to write to
string path = Combine(CurrentDirectory, "people.xml");
using(FileStream stream = File.Create(path))
{
    // serialize the object graph to the stream
    xs.Serialize(stream, people);
}
WriteLine("Written {0:N0} bytes of XML to {1}",
    arg0: new FileInfo(path).Length,
    arg1: path);
WriteLine();
// Display the serialized object graph
WriteLine(File.ReadAllText(path));

// deserialize
using(FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    // deserialize and cast the object graph into a List of Person
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.",
                arg0: p.LastName, arg1: p.Children?.Count ?? 0);
        }
    }
}

// create a file to write to
string jsonPath = Combine(CurrentDirectory, "people.json");
using(StreamWriter jsonStream = File.CreateText(jsonPath))
{
    // create an objec tthat will format as JSON
    Newtonsoft.Json.JsonSerializer jss = new();
    // serialize the object graph into a string
    jss.Serialize(jsonStream, people);
}
WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}",
    arg0: new FileInfo(jsonPath).Length,
    arg1: jsonPath);
// Display the serialized object graph
WriteLine(File.ReadAllText(jsonPath));

using(FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    // deserialize objec tgraph into a List of Person
    List<Person>? loadedPeople = await NewJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;
    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.",
                p.LastName, p.Children?.Count ?? 0);
        }
    }
}