using System;
using System.Collections.Generic;
using System.Linq;
using EMS.DB.Models;
using EMS.DAL.DTO;
using EMS.DAL.Interfaces;

namespace EMS.DAL.DAL;

public class RolesDAL : IRolesDAL
{
    private readonly AlekhyaEmployeeDbContext _context;
    
    public RolesDAL(AlekhyaEmployeeDbContext context)
    {
        _context = context;
    }

    public List<Role> GetAllRoles()
    {
        return _context.Roles.ToList();
    }

    public Role GetRoleFromName(string roleName)
    {
        return _context.Roles.FirstOrDefault(r => r.Name == roleName);
    }

    public Role GetRoleById(int roleId)
    {
        return _context.Roles.Find(roleId);
    }
    
    public int AddRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
        return role.Id;
    }
}
