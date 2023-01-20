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
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: HomeController/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        // GET: GameController/Games
        public IActionResult Games()
        {
            return RedirectToAction("AllGames", "Game");
        }

        // GET: GenreController/Games
        [HttpGet]
        public IActionResult Genres()
        {
            return RedirectToAction("AllGenres", "Genre");
        }

        // GET: HomeController/
        public IActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetObject<User>("loggedUser") != null)
            {
                HttpContext.Session.Remove("loggedUser");
                return RedirectToAction("Home", "Login");
            }

            return View();
        }

        // POST: HomeController/Login
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = _context.Users
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

        // GET: HomeController/Logout
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

        // GET: HomeController/Registration
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        // POST: HomeController/Registration
        [HttpPost]
        public IActionResult Registration(RegistrationVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                PasswordHash = passwordHash,
                Role = "user" // default
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login", "Home");
        }
    }
}
