using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public class UserRolesExchange : IUserRolesExchange
    {
        public UserRoleModel Pack(UserRole userRole)
        {
            return new UserRoleModel
            { 
                Id = userRole.Id,
                Name = userRole.Name
            };
        }

        public IEnumerable<UserRoleModel> Pack(IEnumerable<UserRole> userRoleList) 
        {
            List<UserRoleModel?> modelList = new List<UserRoleModel?>();
            if (userRoleList == null)
            {
                return modelList;
            }

            foreach (UserRole? userRole in userRoleList)
            {
                modelList.Add(Pack(userRole));
            }

            return modelList;
        }
    }
}
