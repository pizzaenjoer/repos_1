using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Model;
using Project.Repository;

namespace Project.Pages
{
    public class CreateMileageModel : PageModel
    {
        private readonly AppDbContext _db; // Çàìåíèòå YourDbContext íà âàø êîíòåêñò áàçû äàííûõ

        [BindProperty]
        public List<Mileage> Mileages { get; set; }

        [BindProperty]
        public Mileage Mileage { get; set; }
        public CreateMileageModel(AppDbContext db)
        {
            _db = db;
            Mileages = _db.Mileage.ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var existingSubject = _db.Mileage.FirstOrDefault(s => s.Name == Mileage.Name);
            if (existingSubject != null)
            {
                ModelState.AddModelError("Subject.Name", "Ïðåäìåò ñ òàêèì èìåíåì óæå ñóùåñòâóåò.");
                return Page();
            }

            _db.Mileage.Add(Mileage);
            _db.SaveChanges();
            Mileages = _db.Mileage.ToList();

            return RedirectToPage("/CreateSubject");
        }
    }
}
