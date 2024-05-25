using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите марку машины")] 
        public string BrandCar { get; set; }
        [Required(ErrorMessage = "Введите модель")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Введите тип двигателя")]
        public string EngineCar { get; set; }
        public List<Mileages> Mileages { get; set; }

        public Car() 
        { 
            BrandCar ??= string.Empty;
            Model ??= string.Empty;
            EngineCar ??= string.Empty;
            Mileages ??= new();
        }
    }
}