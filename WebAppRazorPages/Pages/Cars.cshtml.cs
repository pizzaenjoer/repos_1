using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Repository;
using Project.Model;
using Microsoft.AspNetCore.Authorization;

namespace Project.Pages
{
    [Authorize]
    public class CarsModel : PageModel
    {
        public CarsModel(ICar carRepository) 
        {
            _carRepository = carRepository;
        }
        private ICar _carRepository;
        public List<Car> cars { get; set; }
        public IActionResult OnGet()
        {
            cars = _carRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _carRepository.DeleteCar(id);
            return RedirectToPage();
        }
    }
}
