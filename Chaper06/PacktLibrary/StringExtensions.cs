using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packt.Shared;

// added static
public static class StringExtensions
{
    // added this
    public static bool IsValidEmail(this string input)
    {
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }
}

//added two keyword that it should treat the method as one that extends the string type
