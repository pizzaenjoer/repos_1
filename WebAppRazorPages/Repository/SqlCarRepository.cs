using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Repository
{
    public class SqlCarRepository : ICar
    {
        private readonly AppDbContext _appDbContext;

        public SqlCarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Car Add(Car Icar)
        {
            return Icar;
        }
        public Car DeleteCar(int Id)
        {
            var car = GetCar(Id);
            _appDbContext.Remove(car);
            _appDbContext.SaveChanges();
            return car;
        }

        public Car? GetCar(int Id)
        {
            return _appDbContext.Cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Car> GetAll()
        {
            return _appDbContext.Cars.ToList();
        }

        public Car UpdateCar(Car upCar)
        {
            if (upCar.Id == 0)
            {
                _appDbContext.Cars.Add(upCar);
            }
            else
            {
                _appDbContext.Cars.Update(upCar);
            }
            _appDbContext.SaveChanges();
            return upCar;
        }
    }
}
