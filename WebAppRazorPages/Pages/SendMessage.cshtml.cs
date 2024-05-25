using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages
{
    public class SendMessageModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }

        public void OnGet()
        {
            UserName = User?.Identity?.Name;
        }
    }
}
