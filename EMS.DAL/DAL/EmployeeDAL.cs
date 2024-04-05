using System;
using System.Collections.Generic;
using System.Linq;
using EMS.DB.Models;
using EMS.DAL.DTO;
using EMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL.DAL;
public class EmployeeDAL : IEmployeeDAL
{
    private readonly AlekhyaEmployeeDbContext _context;
    private readonly IMasterDataDal _masterDataDal;
    private readonly IRolesDAL _rolesDal;
    
    public EmployeeDAL(AlekhyaEmployeeDbContext context, IMasterDataDal masterDataDal, IRolesDAL rolesDal)
    {
        _context = context;
        _masterDataDal = masterDataDal;
        _rolesDal = rolesDal;
    }
    
    public int Insert(EmployeeDetail employeeDetail)
    {
        try
        {
            var locationId = _masterDataDal.GetLocationFromName(employeeDetail.LocationName)?.Id;
            var departmentId = _masterDataDal.GetDepartmentFromName(employeeDetail.DepartmentName)?.Id;
            var roleId = _rolesDal.GetRoleFromName(employeeDetail.RoleName)?.Id;
            var managerId = _masterDataDal.GetManagerFromName(employeeDetail.ManagerName)?.Id;
            var projectId = _masterDataDal.GetProjectFromName(employeeDetail.ProjectName)?.Id;
            var employee = new Employee
            {
                Uid = employeeDetail.Uid,
                FirstName = employeeDetail.FirstName,
                LastName = employeeDetail.LastName,
                Dob = employeeDetail.Dob,
                Email = employeeDetail.Email,
                MobileNumber = employeeDetail.MobileNumber,
                JoiningDate = employeeDetail.JoiningDate,
                LocationId = locationId,
                DepartmentId = departmentId,
                RoleId = roleId,
                IsManager = employeeDetail.IsManager,
                ManagerId = managerId,
                ProjectId = projectId,
            };
            if (employeeDetail.IsManager)
            {
                employee.ManagerId = null;
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }
        catch
        {
            return -1;
        }
    }
    
    public int Update(EmployeeDetail employeeDetail)
    {
        var locationId = _masterDataDal.GetLocationFromName(employeeDetail.LocationName)?.Id;
        var departmentId = _masterDataDal.GetDepartmentFromName(employeeDetail.DepartmentName)?.Id;
        var roleId = _rolesDal.GetRoleFromName(employeeDetail.RoleName)?.Id;
        var managerId = _masterDataDal.GetManagerFromName(employeeDetail.ManagerName)?.Id;
        var projectId = _masterDataDal.GetProjectFromName(employeeDetail.ProjectName)?.Id;
        var employee = new Employee
        {
            Uid = employeeDetail.Uid,
            FirstName = employeeDetail.FirstName,
            LastName = employeeDetail.LastName,
            Dob = employeeDetail.Dob,
            Email = employeeDetail.Email,
            MobileNumber = employeeDetail.MobileNumber,
            JoiningDate = employeeDetail.JoiningDate,
            LocationId = locationId,
            DepartmentId = departmentId,
            RoleId = roleId,
            IsManager = employeeDetail.IsManager,
            ManagerId = managerId,
            ProjectId = projectId,
        };
        if (employeeDetail.IsManager)
        {
            employee.ManagerId = null;
        }
        _context.Employees.Update(employee);
        return _context.SaveChanges();
    }

    public int Delete(int Id)
    {
        var employee = _context.Employees.Find(Id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            return _context.SaveChanges();
        }
        return 0;
    }

    public List<EmployeeDetail> Filter(EmployeeFilter filters)
    {
        var query = _context.Employees
            .Include(e => e.Location)
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Include(e => e.Manager)
            .Include(e => e.Project)
            .Select(e => new EmployeeDetail
            {
                Id = e.Id,
                Uid = e.Uid,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Dob = e.Dob,
                Email = e.Email,
                MobileNumber = e.MobileNumber,
                JoiningDate = e.JoiningDate,
                LocationName = e.Location.Name,
                DepartmentName = e.Department.Name,
                RoleName = e.Role.Name,
                IsManager = e.IsManager,
                ManagerName = e.Manager != null ? e.Manager.FirstName : "Null",
                ProjectName = e.Project.Name
            });
        if (!string.IsNullOrEmpty(filters.FirstName))
        {
            query = query.Where(e => e.FirstName.StartsWith(filters.FirstName));
        }
        if (filters.LocationId.HasValue)
        {
            var locationName = _context.Locations
                .Where(l => l.Id == filters.LocationId)
                .Select(l => l.Name).FirstOrDefault();

            query = query.Where(e => e.LocationName == locationName);
        }
        if (filters.DepartmentId.HasValue)
        {
            var departmentName = _context.Departments
                .Where(d => d.Id == filters.DepartmentId)
                .Select(d => d.Name).FirstOrDefault();

            query = query.Where(e => e.DepartmentName == departmentName);
        }
        if (filters.Id.HasValue)
        {
            query = query.Where(e => e.Id == filters.Id);
        }

        return query.ToList();
    }

    public List<EmployeeDetail> GetAll()
    {
        return _context.Employees
            .Include(e => e.Location)
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Include(e => e.Manager)
            .Include(e => e.Project)
            .Select(e => new EmployeeDetail
            {
                Id = e.Id,
                Uid = e.Uid,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Dob = e.Dob,
                Email = e.Email,
                MobileNumber = e.MobileNumber,
                JoiningDate = e.JoiningDate,
                LocationName = e.Location.Name,
                DepartmentName = e.Department.Name,
                RoleName = e.Role.Name,
                IsManager = e.IsManager,
                ManagerName = e.Manager != null ? e.Manager.FirstName : "Null",
                ProjectName = e.Project.Name
            })
            .ToList();
    }
}

