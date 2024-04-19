using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Implementation
{
    public class UserRepository : IUser
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }



        public bool Put([FromBody] User updatedUser)
        {
            User? userToUpdate = _context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);

            if (userToUpdate == null)
                return false;


            userToUpdate.Username = updatedUser.Username;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Password = updatedUser.Password;
            _context.SaveChanges();

            return true;
        }


        public bool IsUserPresent(User user)
        {
            var IsPresent = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (IsPresent == null)
                return false;

            return true;
        }


        public User AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

    }
}
