using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class HabitsController : Controller
    {

        private IHabit _habitrepo;


        public HabitsController(AppDbContext context, IHabit h)
        {
            _habitrepo = h;
        }


        // GET: HabitsController
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_habitrepo.Get());
        }





        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status208AlreadyReported)]
        public IActionResult Post([FromBody] Habit newHabit)
        {

            if (_habitrepo.Post(newHabit) != null)
                return Ok("Habit Added Successfully!!");

            return StatusCode(StatusCodes.Status208AlreadyReported);
        }





        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromBody] Habit updatedHabit)
        {

            if (_habitrepo.Put(updatedHabit) != null)
                return Ok("Habit Updated Successfully!!");

            return NotFound();
        }





        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Delete(int id)
        {

            if (_habitrepo.Delete(id))
                return Ok("Habit Deleted Successfully!!");

            return NotFound("Element Not Found!!");
        }


    }
}
