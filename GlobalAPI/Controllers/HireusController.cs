using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HireusController : ControllerBase
    {
        private readonly HireusService _hireusService;

        public HireusController(HireusService hireusService)
        {
            _hireusService = hireusService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hireus>> GetAllHireuses()
        {
            return _hireusService.GetAllHireuses();
        }

        [HttpGet("{id}")]
        public ActionResult<Hireus> GetHireusById(int id)
        {
            var hireus = _hireusService.GetHireusById(id);

            if (hireus == null)
            {
                return NotFound();
            }

            return hireus;
        }

        [HttpPost]
        public IActionResult AddHireus(Hireus hireus)
        {
            _hireusService.AddHireus(hireus);
            return CreatedAtAction(nameof(GetHireusById), new { id = hireus.Id }, hireus);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHireus(int id, Hireus hireus)
        {
            if (id != hireus.Id)
            {
                return BadRequest();
            }

            _hireusService.UpdateHireus(hireus);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHireus(int id)
        {
            _hireusService.DeleteHireus(id);

            return NoContent();
        }
    }
}
