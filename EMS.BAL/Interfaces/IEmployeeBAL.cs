using System.Collections.Generic;
using EMS.DB.Models;
using EMS.DAL.DTO;

namespace EMS.BAL.Interfaces;

public interface IEmployeeBAL
{
    int Add(EmployeeDetail employeeDetail) ;
    int Update(EmployeeDetail updatedEmployee);
    int Delete(IEnumerable<int> ids);
    List<EmployeeDetail> Filter(EmployeeFilter filters);
    List<EmployeeDetail> GetAllEmployees();
}