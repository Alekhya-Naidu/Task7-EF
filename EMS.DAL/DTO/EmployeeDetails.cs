using System;
using System.Collections.Generic;
using EMS.DB.Models;

namespace EMS.DAL.DTO;

public class EmployeeDetail
{
    public int Id { get; set; }
    public string? Uid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly Dob { get; set; }
    public string Email { get; set; } = null!;
    public string? MobileNumber { get; set; }
    public DateOnly? JoiningDate { get; set; }
    public string? LocationName { get; set; }
    public string? DepartmentName { get; set; }
    public string? RoleName { get; set; }
    public bool IsManager { get; set; }
    public string? ManagerName { get; set; }
    public string? ProjectName { get; set; }
}
