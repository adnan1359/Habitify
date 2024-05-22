using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Implementation;
using Habitify.Repository.Interface;
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
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {

        private IUser _userrepo;
        private IConfiguration _config;


        public UsersController(IConfiguration config, IUser u)
        {
            _config = config;
            _userrepo = u;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userrepo.GetAllUsers());
        }


        [HttpGet("GetUserIdByEmail")]
        [Authorize]
        public IActionResult GetUserIdByEmail(string email)
        {
            var userId = _userrepo.GetUserIdByEmail(email);

            if (userId == null)
            {
                return NotFound("User not found");
            }

            return Ok(userId);
        }


        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public IActionResult Put([FromBody] User updatedUser)
        {
            
            if (_userrepo.Put(updatedUser))
                return Ok("User Details Updated Successfully!!");

            return StatusCode(StatusCodes.Status304NotModified);
            
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Login([FromBody] User user)
        {
            
            bool? currentUser = _userrepo.IsUserPresent(user);

            if (currentUser == null)
                return NotFound();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            if (securityKey.KeySize < 256)
            {
                
                securityKey = new SymmetricSecurityKey(new byte[256 / 8]);
            }

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

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


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status208AlreadyReported)]
        public IActionResult Register([FromBody] User newUser)
        {
            bool? currentUser = _userrepo.IsUserPresent(newUser);

            if (currentUser == true)
                return StatusCode(StatusCodes.Status208AlreadyReported);

            _userrepo.AddUser(newUser);
            return Ok("User Registered Successfully!!");
        }

        /*
        [HttpGet("GetUserIdByEmail")]
        [Authorize]
        public IActionResult GetUserIdByEmail(string email)
        {
            var userId = _userrepo.GetUserIdByEmail(email);

            if (userId == null)
            {
                return NotFound("User not found");
            }

            return Ok(userId);
        }
    */

    }
}
