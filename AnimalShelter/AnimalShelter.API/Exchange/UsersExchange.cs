using AnimalShelter.API.Models;
using AnimalShelter.Domain.Common;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public class UsersExchange : IUsersExchange
    {
        private IUserRolesExchange _userRolesExchange;
        public UsersExchange(IUserRolesExchange userRolesExchange) 
        {
            _userRolesExchange = userRolesExchange;
        }
        
        public IEnumerable<UserModel> Pack(IEnumerable<User> userList)
        {
            List<UserModel?> modelList = new List<UserModel?>();
            if (userList == null)
            {
                return modelList;
            }

            foreach (User? user in userList)
            {
                modelList.Add(Pack(user));
            }

            return modelList;
        }

        public UserModel Pack(User user)
        {
            return new UserModel 
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                UserRole = _userRolesExchange.Pack(user.UserRole)
            };
        }

        public JwtTokenModel Pack(JwtToken jwtToken)
        {
            return new JwtTokenModel
            {
                AccessToken = jwtToken.AccessToken,
                AccessTokenExpiration = jwtToken.AccessTokenExpiration,
            };
        }

        public User Unpack(UserCreationModel userCreationModel)
        {
            return new User 
            {
                Id = userCreationModel.Id,
                FirstName = userCreationModel.FirstName,
                LastName = userCreationModel.LastName,
                Username= userCreationModel.Username,
                Password = userCreationModel.Password,
                UserRoleId = userCreationModel.UserRoleId
            };
        }
    }
}
