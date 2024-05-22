using Habitify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Interface
{
    public interface IUser
    {
        bool Put([FromBody] User updatedUser);

        bool IsUserPresent(User user);


        User AddUser(User newUser);

        public int GetUserIdByEmail(string email);

        public IEnumerable<User> GetAllUsers();

    }
}
