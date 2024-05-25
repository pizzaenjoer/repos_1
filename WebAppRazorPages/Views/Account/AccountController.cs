using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Project.Model.AuthApp;
using Project.Repository;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AuthUser user = _db.AuthUsers.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Authenticate(user.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверный логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AuthUser user = _db.AuthUsers.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    AuthUser newUser = new AuthUser { Email = model.Email, Password = model.Password };
                    _db.AuthUsers.Add(newUser);
                    _db.SaveChanges();

                    Authenticate(newUser.Email);

                    Response.Cookies.Append("UserId", newUser.Id.ToString());
                    Response.Cookies.Append("UserEmail", newUser.Email);

                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким email уже существует");
                }
            }
            return View(model);
        }


        private async void Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}