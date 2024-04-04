using System.Collections.Generic;
using EMS.DB.Models;

namespace EMS.BAL.Interfaces;

public interface IRolesBAL
{
    List<Role> GetAllRoles();
    Role GetRoleFromName(string roleInput);
    Role GetRoleById(int roleId);
    int AddRole(Role role);
}