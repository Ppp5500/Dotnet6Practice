#pragma warning disable CS0649
using static System.Console;

//Address address = new();
//address.Building = null;
//address.Street = null;
//address.City = "London";
//address.Region = null;

string? authorName = null;
// the following throws a NullReferenceException
// int x = authorName.Length;
// instead of throwing an exception, null is assinged to y
int? y = authorName?.Length;
WriteLine(y);
// null-coalescing operator ??
int result = authorName?.Length ?? 3;
Console.WriteLine(result);

// int thisCannotBeNull = 4;
// thisCannotBeNull = null; // compile error!
int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());
thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
}

