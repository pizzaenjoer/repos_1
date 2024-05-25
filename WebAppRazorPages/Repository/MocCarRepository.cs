using Project.Model;

namespace Project.Repository
{
    public class MocCarRepository : ICar
    {
        private List<Car> _cars;
        public MocCarRepository() 
        {
            //if (_cars == null) _cars = new List<Car>(); эта строчка равно строчке 11
            _cars ??= new List<Car>();
            _cars.Add(new() { Id = 1, BrandCar = "Ауди", Model = "RS6" ,EngineCar = "Бензиновый"});
            _cars.Add(new() { Id = 2, BrandCar = "BMW", Model = "E-39", EngineCar = "Бензиновый" });
            _cars.Add(new() { Id = 3, BrandCar = "Nissan", Model = "Primera P11", EngineCar = "Бензиновый"});
        }
        public Car Add(Car Icar)
        {
            _cars.Add(Icar);
            return Icar;
        }

        public Car DeleteCar(int Id)
        {
            var car = GetCar(Id);
            _cars.Remove(car);
            return car;
        }

        public Car? GetCar(int Id) 
        {
            return _cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Car> GetAll() 
        {
            return _cars;
        }

        public Car UpdateCar(Car upCar)
        {
            var carDB = GetCar(upCar.Id);
            if (carDB != null)
            {
                _cars.Remove(carDB);
            }
            _cars.Add(upCar);
            return upCar;
        }

    }
}
