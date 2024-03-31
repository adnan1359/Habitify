using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Habitify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly AppDbContext _context;
        //private readonly UserRepository _repository;
        private IConfiguration _config;


        public UsersController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
            //_repository = repository;
        }


        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] User updatedUser)
        {
            /*
            if (_repository.Put(updatedUser))
                return Ok("User Details Updated Successfully!!");

            return StatusCode(StatusCodes.Status304NotModified);

            */
            User? userToUpdate = _context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);

            if (userToUpdate == null)
                return NotFound();


            userToUpdate.Username = updatedUser.Username;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Password = updatedUser.Password;
            _context.SaveChanges();

            return Ok("Details Updated Successfully");
            
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            //bool? currentUser = _repository.IsUserPresent(user);

            if (currentUser == null)
                return NotFound();

            // Used to encrypt and decrypt the data
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            if (securityKey.KeySize < 256)
            {
                // Generate a new security key with a sufficient key size (e.g., 256 bits)
                securityKey = new SymmetricSecurityKey(new byte[256 / 8]);
            }

            // To Hash our credential key
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            // Initialize the JWT Token Class
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1440),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt);
        }













        /*
        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        */
    }
}
