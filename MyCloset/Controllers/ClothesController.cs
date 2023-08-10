using Microsoft.AspNetCore.Mvc;
using MyCloset.Models;
using MyCloset.Repositories;

namespace MyCloset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesRepository _clothesRepository;

        public ClothesController(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        // GET: api/Clothes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clothesRepository.GetAll());
        }

        // GET: api/Clothes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clothes = _clothesRepository.GetById(id);

            if (clothes == null)
            {
                return NotFound();
            }

            return Ok(clothes);
        }

        // POST: api/Clothes
        [HttpPost]
        public IActionResult Post(Clothes clothes)
        {
            _clothesRepository.Add(clothes);
            return CreatedAtAction(nameof(Get), new { id = clothes.Id }, clothes);
        }

        // PUT: api/Clothes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return BadRequest();
            }

            _clothesRepository.Update(clothes);
            return NoContent();
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clothesRepository.Delete(id);
            return NoContent();
        }
    }
}