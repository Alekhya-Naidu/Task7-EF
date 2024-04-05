using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EMS.DB.Models;
using EMS.DAL.DTO;

namespace EMS.DAL.Interfaces;

public interface IEmployeeDAL
{
    int Insert(EmployeeDetail employeeDetail);
    int Update(EmployeeDetail employee);
    int Delete(int id);
    List<EmployeeDetail> Filter(EmployeeFilter filters);
    List<EmployeeDetail> GetAll();
}