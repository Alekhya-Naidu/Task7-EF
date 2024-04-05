using System;
using System.Collections.Generic;
using System.Linq;
using EMS.DB.Models;
using EMS.DAL.Interfaces;
namespace EMS.DAL.DAL;

public class MasterDataDAL : IMasterDataDal
{
    private readonly AlekhyaEmployeeDbContext _context;

    public MasterDataDAL(AlekhyaEmployeeDbContext context)
    {
        _context = context;
    }

    public List<Location> GetAllLocations()
    {
        return _context.Locations.ToList();
    }

    public List<Department> GetAllDepartments()
    {
        return _context.Departments.ToList();
    }

    public List<Manager> GetAllManagers()
    {
        return _context.Managers.ToList();
    }

    public List<Project> GetAllProjects()
    {
        return _context.Projects.ToList();
    }

    public Location GetLocationFromName(string locationName)
    {
        return _context.Locations.FirstOrDefault(l => l.Name == locationName);
    }

    public Department GetDepartmentFromName(string departmentName)
    {
        return _context.Departments.FirstOrDefault(d => d.Name == departmentName);
    }

    public Manager GetManagerFromName(string managerName)
    {
        return _context.Managers.FirstOrDefault(m => m.FirstName == managerName);
    }

    public Project GetProjectFromName(string projectName)
    {
        return _context.Projects.FirstOrDefault(p => p.Name == projectName);
    }

    public Location GetLocationById(int locationId)
    {
        return _context.Locations.Find(locationId);
    }

    public Department GetDepartmentById(int departmentId)
    {
        return _context.Departments.Find(departmentId);
    }

    public string GetManagerNameById(int managerId)
    {
        var manager =  _context.Managers.FirstOrDefault(e => e.Id == managerId);
        if (manager != null)
        {
            return manager.FirstName;
        }
        else
        {
            return null;
        }
    }

    public Project GetProjectById(int projectId)
    {
        return _context.Projects.Find(projectId);
    }
}