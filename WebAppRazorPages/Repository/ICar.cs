using Project.Model;

namespace Project.Repository
{
    public interface ICar
    {
        public Car Add(Car Icar);
        public Car? GetCar(int Id);
        public List<Car> GetAll();
        public Car UpdateCar(Car upCar);
        public Car DeleteCar(int Id);
    }
}
