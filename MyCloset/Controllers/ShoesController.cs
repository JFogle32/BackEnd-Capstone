using Microsoft.AspNetCore.Mvc;
using MyCloset.Models;
using MyCloset.Repositories;

namespace MyCloset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesRepository _shoeRepository;

        public ShoesController(IShoesRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        // GET: api/Shoes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shoeRepository.GetAll());
        }

        // GET: api/Shoe/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shoe = _shoeRepository.GetById(id);
            if (shoe == null) return NotFound();
            return Ok(shoe);
        }

        // POST: api/Shoe
        [HttpPost]
        public IActionResult Post(Shoes shoe)
        {
            _shoeRepository.Add(shoe);
            return CreatedAtAction(nameof(Get), new { id = shoe.Id }, shoe);
        }

        // PUT: api/Shoe/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Shoes shoe)
        {
            if (id != shoe.Id) return BadRequest();

            _shoeRepository.Update(shoe);
            return NoContent();
        }

        // DELETE: api/Shoe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _shoeRepository.Delete(id);
            return NoContent();
        }
    }
}
