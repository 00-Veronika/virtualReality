using System.Diagnostics;
using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Models;
using virtualReality.ViewModels;

namespace virtualReality.Controllers
{
    public class HomeController : Controller
    {
        // GET: GenreController/Details
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        // GET: GenreController/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        // GET: GenreController/Games
        public IActionResult Games()
        {
            return RedirectToAction("AllGames", "Game");
        }


        [HttpGet]
        public IActionResult Genres()
        {
            return RedirectToAction("AllGenres", "Genre");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetObject<User>("loggedUser") != null)
            {
                return RedirectToAction("Home", "Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var context = new MyDbContext();
            User user = context.Users
                .Where(u => u.UserName == model.Username)
                .FirstOrDefault();

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetObject<User>("loggedUser") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var context = new MyDbContext();
            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                PasswordHash = passwordHash,
                Role = "user"
            };

            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("Login", "Home");
        }
    }
}
