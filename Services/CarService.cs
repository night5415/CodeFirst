using Code_First.Contexts;
using Code_First.Entities;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Services
{
    public interface ICarService
    {
        public Task<List<Cars>> GetAllCarsAsync();
        public Task<Cars?> GetCarByIdAsync(int id);
        public Task<Cars?> AddCarAsync(Cars car);
        public Task<Cars?> UpdateCarAsync(Cars car);
        public Task<Cars?> DeleteCarAsync(Cars car);
    }


    public class CarService : ICarService
    {
        private readonly CarContext _context;

        public CarService(CarContext context)
        {
            _context = context;
        }

        public async Task<Cars?> AddCarAsync(Cars car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Cars?> DeleteCarAsync(Cars car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<List<Cars>> GetAllCarsAsync()
        {
            var cars = await _context.Cars.ToListAsync();

            return cars;
        }

        public async Task<Cars?> GetCarByIdAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            return car;
        }

        public async Task<Cars?> UpdateCarAsync(Cars car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
