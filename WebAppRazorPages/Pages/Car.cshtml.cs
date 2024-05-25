using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Repository;
using Project.Model;
using Microsoft.AspNetCore.Authorization;

namespace Project.Pages
{
    [Authorize]
    public class CarModel : PageModel
    {
        public CarModel(ICar carRepository)
        {
            _carRepository = carRepository;
        }
        private ICar _carRepository;
        public Car? Car { get; set; }
        public IActionResult OnGet(int id_car)
        {
            Car = _carRepository.GetCar(id_car);
            if (Car == null) return NotFound(); 
            return Page();
        }
    }
}
