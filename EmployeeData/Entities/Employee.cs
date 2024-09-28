using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Entities;

public class Employee: Base
{
    [MaxLength(100)]
    public string Name { get; init; } = string.Empty;
    
    public List<Role> Roles { get; set; } = [];
}