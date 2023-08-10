using Microsoft.AspNetCore.Mvc;
using MyCloset.Models;
using MyCloset.Repositories;

namespace MyCloset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly IGadgetsRepository _gadgetRepository;

        public GadgetsController(IGadgetsRepository gadgetRepository)
        {
            _gadgetRepository = gadgetRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gadgetRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var gadget = _gadgetRepository.GetById(id);
            if (gadget == null)
            {
                return NotFound();
            }
            return Ok(gadget);
        }

        [HttpPost]
        public IActionResult Post(Gadgets gadget)
        {
            _gadgetRepository.Add(gadget);
            return CreatedAtAction(nameof(Get), new { id = gadget.Id }, gadget);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Gadgets gadget)
        {
            if (id != gadget.Id)
            {
                return BadRequest();
            }

            _gadgetRepository.Update(gadget);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _gadgetRepository.Delete(id);
            return NoContent();
        }
    }
}