using Habitify.Data;
using Habitify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        // GET: UsersController
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }


        // GET: UsersController
        [HttpGet]
        //[Route("~/api/users/Get")]
        public IActionResult Get()
        {
            return Ok(_context.Users);
        }




        [HttpPost]
        //[Route("~/api/users/post")]
        public IActionResult Post([FromBody] User newUser)
        {

            User? IsPresent = _context.Users.FirstOrDefault(x=>x.UserId==newUser.UserId);

            if (IsPresent != null)
                return StatusCode(StatusCodes.Status208AlreadyReported);

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok("User Added Successfully!!");
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
