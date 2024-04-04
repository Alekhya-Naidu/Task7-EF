using System;
using System.Collections.Generic;
using EMS.DB.Models;

namespace EMS.DAL.DTO;

public partial class EmployeeFilter
{
    public int? Id { get; set; }
    public string? FirstName { get; set; } = null!;
    public int? LocationId { get; set; }
    public int? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
    public virtual Location? Location { get; set; }
}
