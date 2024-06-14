using Code_First.Contexts;
using Code_First.Entities;
using Code_First.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        //private readonly CarContext _context;
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var cars = await _service.GetAllCarsAsync();
            return Ok(cars);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var car = await _service.GetCarByIdAsync(id);

            return car is null
                ? NotFound($"Car with id of {id} not found")
                : Ok(car);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cars car)
        {
            await _service.AddCarAsync(car);
            return Ok(car);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] Cars car)
        {
            await _service.UpdateCarAsync(car);

            return Ok(car);
        }


        [HttpDelete()]
        public async Task<ActionResult> Delete([FromBody] Cars car)
        {
            await _service.DeleteCarAsync(car);

            return Ok(car);
        }
    }
}
