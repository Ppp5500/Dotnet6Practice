using System.Numerics;
using static System.Console;

WriteLine("Working with large integers:");
WriteLine("----------------------------");
ulong big = ulong.MaxValue;
WriteLine($"{big,40:N0}");
BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,40:N0}");

// Working with complex numbers
WriteLine("Working with complex numbers:");
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

// output using default ToString implementation
WriteLine($"{c1} added to {c2} is {c3}");
// output sing custom format
WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i",
    c1.Real, c1.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"First char is {city[0]} and third is {city[2]}.");

string cities = "Paris, Tehran, Chennai, Sydney, New York, Medellin";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array.");
foreach(string item in citiesArray)
{
    WriteLine(item);
}

// Getting part of a string
string fullName = "Alan jones";
int indexOfTheSpace = fullName.IndexOf(' ');
string firstName = fullName.Substring(startIndex: 0, length: indexOfTheSpace);
string lastName = fullName.Substring(startIndex: indexOfTheSpace +1); ;
WriteLine($"Orihinal: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

// Checking a string for content
string company = "Microsoft";
bool startsWithM = company.StartsWith("M");
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Stats with M: {startsWithM}, contains an N: {containsN}");

// Joining, fomatting, and other string members