using AnimalShelter.API.Models;
using AnimalShelter.Domain.Common;
using AnimalShelter.Domain.Entities;
using Org.BouncyCastle.Bcpg;

namespace AnimalShelter.API.Exchange
{
    public interface IUsersExchange
    {
        IEnumerable<UserModel> Pack(IEnumerable<User> userList);
        UserModel Pack(User user);

        User Unpack(UserCreationModel userCreationModel);

        JwtTokenModel Pack(JwtToken jwtToken);
    }
}
