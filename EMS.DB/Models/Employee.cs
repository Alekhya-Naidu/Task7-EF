using System;
using System.Collections.Generic;

namespace EMS.DB.Models;

public partial class Employee
{
    public int Id { get; set; }
    public string? Uid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly Dob { get; set; }
    public string Email { get; set; } = null!;
    public string? MobileNumber { get; set; }
    public DateOnly? JoiningDate { get; set; }
    public int? LocationId { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }
    public bool IsManager { get; set; }
    public int? ManagerId { get; set; }
    public int? ProjectId { get; set; }
    public virtual Department? Department { get; set; }
    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();
    public virtual Location? Location { get; set; }
    public virtual Employee? Manager { get; set; }
    public virtual Project? Project { get; set; }
    public virtual Role? Role { get; set; }
}
