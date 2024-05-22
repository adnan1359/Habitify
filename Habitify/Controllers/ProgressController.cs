using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProgressController : Controller
    {
        private IProgress _progressrepo;


        public ProgressController(AppDbContext context, IProgress p)
        {
            _progressrepo = p;
        }



        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            return Ok(_progressrepo.Get(id));
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_progressrepo.GetAllProgress());
        }




        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status208AlreadyReported)]
        public IActionResult Post([FromBody] Progress progress)
        {

            if (_progressrepo.Post(progress))
                return Ok("Progress Added Successfully!!");

            return StatusCode(StatusCodes.Status208AlreadyReported);
        }



        [HttpGet("completed/{habitId}")]
        [Authorize]
        public IActionResult GetCompletedHabits(int habitId)
        {
            return Ok(_progressrepo.GetCompletedHabits(habitId));
        }
     


    }
}
