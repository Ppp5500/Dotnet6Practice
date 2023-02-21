using System.ComponentModel.DataAnnotations; // [Required], [StringLength]

namespace Packt.Shared;

public class Employee
{
    public int EmployeeId { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    [StringLength(15)]
    public string? City { get; set; }
}
