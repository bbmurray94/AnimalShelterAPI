using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IUserRolesExchange
    {
        UserRoleModel Pack(UserRole userRole);
        IEnumerable<UserRoleModel> Pack(IEnumerable<UserRole> userRoleList);
    }
}
