using System.Collections.Generic;
using EMS.DB.Models;

namespace EMS.DAL.Interfaces;

public interface IRolesDAL
{
    List<Role> GetAllRoles();
    Role GetRoleFromName(string roleName);
    Role GetRoleById(int roleId);
    int AddRole(Role role);
}
