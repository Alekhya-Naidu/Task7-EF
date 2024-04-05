using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EMS.BAL.Interfaces;
using EMS.DAL.Interfaces;
using EMS.DB.Models;
using EMS.DAL.DTO;

namespace EMS.BAL.BAL;
public class EmployeeBAL : IEmployeeBAL
{
    private readonly AlekhyaEmployeeDbContext _context;
    private readonly IEmployeeDAL _employeeDal;
     private readonly IMasterDataBal _masterDataBAL;
    private readonly IRolesBAL _rolesBAL;

    public EmployeeBAL(AlekhyaEmployeeDbContext context, IEmployeeDAL employeeDAL,IMasterDataBal masterDataBal, IRolesBAL rolesBAL)
    {
        _context = context;
        _employeeDal = employeeDAL;
        _masterDataBAL = masterDataBal;
        _rolesBAL = rolesBAL;
    }

    public int Add(EmployeeDetail employeeDetail)
    {
        if (!(ValidateEmployeeInputData(employeeDetail)))
        {
            return -1;
        }
        return _employeeDal.Insert(employeeDetail);
    }

    public int Update(EmployeeDetail updatedEmployee)
    {
        int updatedEmployeeCount = 0;
        List<EmployeeDetail> existingEmployees = _employeeDal.GetAll();
        EmployeeDetail existingEmployee = existingEmployees.Find(emp => emp.Id == updatedEmployee.Id);
        if (!(ValidateEmployeeInputData(updatedEmployee)))
        {
            return -1;
        }
        if (existingEmployee != null)
        {
            updatedEmployeeCount += _employeeDal.Update(updatedEmployee);
        }
        return updatedEmployeeCount;
    }

    public int Delete(IEnumerable<int> ids)
    {
        try
        {
            int count = 0;
            foreach (var id in ids)
            {
                count += _employeeDal.Delete(id);
            }
            return count;
        }
        catch
        {
            return -1;
        }
    }

    private bool ValidateEmployeeInputData(EmployeeDetail employeeDetail)
    {
        if(employeeDetail == null || string.Equals(employeeDetail.Uid,"0"))   
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(employeeDetail.FirstName) || string.IsNullOrWhiteSpace(employeeDetail.LastName))
        {
            return false; 
        }
        if(string.IsNullOrWhiteSpace(employeeDetail.Email) || !(employeeDetail.Email.Contains("@") && employeeDetail.Email.Contains(".")))
        {
            return false;
        }
        if(employeeDetail.MobileNumber.Length > 1)
        {
            if(employeeDetail.MobileNumber.Length != 10)
            {
               return false;
            }
        }
        return true;
    }
    
    public List<EmployeeDetail> Filter(EmployeeFilter filters)
    {
        return _employeeDal.Filter(filters);
    }

    public List<EmployeeDetail> GetAllEmployees()
    {
        List<EmployeeDetail> employees = _employeeDal.GetAll();
        if (employees == null)
        {
            employees = new List<EmployeeDetail>(); 
        }
        return employees;
    }
}