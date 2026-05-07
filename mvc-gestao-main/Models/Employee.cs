using System.ComponentModel.DataAnnotations;
namespace EmployeesManagement.Models;
public class Employee : UserActivity {
    public int Id { get; set; }
    [Required] public string EmpNumber { get; set; } = "";
    [Required] public string FirstName { get; set; } = "";
    public string? MiddleName { get; set; }
    [Required] public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {MiddleName} {LastName}".Replace("  "," ").Trim();
    public long PhoneNumber { get; set; }
    [EmailAddress] public string EmailAddress { get; set; } = "";
    public string Country { get; set; } = "";
    [DataType(DataType.Date)] public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = "";
    public string Department { get; set; } = "";
    public string Designation { get; set; } = "";
}
