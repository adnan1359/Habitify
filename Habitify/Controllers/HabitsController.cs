using Habitify.Data;
using Habitify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : Controller
    {
        // GET: UsersController
        private readonly AppDbContext _context;

        public HabitsController(AppDbContext context)
        {
            _context = context;
        }


        // GET: HabitsController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Habits);
        }




        [HttpPost]
        public IActionResult Post([FromBody] Habit newHabit)
        {

            Habit? IsPresent = _context.Habits.FirstOrDefault(h => h.HabitName == newHabit.HabitName);

            if (IsPresent != null)
                return StatusCode(StatusCodes.Status208AlreadyReported);

            _context.Habits.Add(newHabit);
            _context.SaveChanges();
            return Ok("User Added Successfully!!");
        }



        [HttpPut]
        public IActionResult Put([FromBody] Habit updatedHabit)
        {

            Habit? IsPresent = _context.Habits.FirstOrDefault(h => h.HabitName == updatedHabit.HabitName);

            if (IsPresent != null)
                return NotFound();

            _context.Habits.Update(updatedHabit);
            _context.SaveChanges();
            return Ok("Habit Updated Successfully!!");
        }



        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {

            Habit? habitToDelete = _context.Habits.Find(id);

            if (habitToDelete == null)
                return NotFound();

            _context.Habits.Remove(habitToDelete);
            _context.SaveChanges();
            return Ok("Habit Deleted Successfully!!");
        }


    }
}
