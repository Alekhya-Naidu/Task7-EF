using System.Collections.Generic;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.BAL.Interfaces;

public interface IMasterDataBal
{
    List<Location> GetAllLocations();
    List<Department> GetAllDepartments();
    List<Manager> GetAllManagers();
    List<Project> GetAllProjects();
    Location GetLocationFromName(string locationInput);
    Department GetDepartmentFromName(string departmentName);
    Manager GetManagerFromName(string managerName);
    Project GetProjectFromName(string projectName);
    Location GetLocationById(int locationId);
    Department GetDepartmentById(int departmentId);
    string GetManagerNameById(int managerId);
    Project GetProjectById(int projectId);
}