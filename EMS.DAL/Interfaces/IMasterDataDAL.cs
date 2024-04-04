using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.DAL.Interfaces;

public interface IMasterDataDal
{
    List<Location> GetAllLocations();
    List<Department> GetAllDepartments();
    List<Employee> GetAllManagers();
    List<Project> GetAllProjects();
    Location GetLocationFromName(string locationName);
    Department GetDepartmentFromName(string departmentName);
    Employee GetManagerFromName(string managerName);
    Project GetProjectFromName(string projectName);
    Location GetLocationById(int locationId);
    Department GetDepartmentById(int departmentId);
    string GetManagerNameById(int managerId);
    Project GetProjectById(int projectId);
}