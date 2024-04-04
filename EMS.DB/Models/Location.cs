﻿using System;
using System.Collections.Generic;

namespace EMS.DB.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
