using Code_First.Contexts;
using Code_First.Entities;

namespace Code_First.Repositories
{
    public class CarRepository
    {
        private readonly CarContext context;
        public CarRepository(CarContext _context)
        {
            context = _context;
        }

        public void AddCar()
        {
            context.Add(new Cars { Id = 2, Make = "Ford", Model = "Mustang" });
            context.SaveChanges();
        }
    }
}
