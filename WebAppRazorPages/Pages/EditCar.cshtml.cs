using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Model;
using Project.Repository;

namespace Project.Pages
{
    [Authorize]
    public class EditCarModel : PageModel
    {
        public EditCarModel(ICar CarRepository)
        {
            _CarRepository = CarRepository;
        }

        private ICar _CarRepository;
        public Car? Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _CarRepository.GetCar(id);
            Car ??= new();
            return Page();
        }

        public IActionResult OnPost(Car CarForm)
        {
            Car = _CarRepository.UpdateCar(CarForm);

            if (Car == null) return NotFound();

            return RedirectToPage("Cars");
        }
    }
}