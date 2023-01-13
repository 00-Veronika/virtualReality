using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Models;
using virtualReality.Services.GameService;
using virtualReality.Services.OrderService;
using virtualReality.ViewModels;
using virtualReality.ViewModels.GenreVM;


namespace virtualReality.Controllers
{
    public class HomeController : Controller
    {
        private int counter = 0;
        private readonly IOrderServices _orderServices;
        private readonly IGameServices _gameServices;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, IOrderServices orderServices, IGameServices gameServices)
        {
            _logger = logger;
            _orderServices = orderServices;
            _gameServices = gameServices;

        }


        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Games()
        {
            return RedirectToAction("AllGames", "Games");
        }

        [HttpGet]
        public IActionResult Genres()
        {
            return RedirectToAction("AllGenres","Genre");
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
            if (!this.ModelState.IsValid)
                return View(model);

            MyDbContext context = new MyDbContext();
            User loggedUser = context.Users.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                           .FirstOrDefault();
            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

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

            MyDbContext context = new MyDbContext();
            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.Email = model.Email;
            item.Phone = model.Phone;

            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Login", "Home");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            if (this.HttpContext.Session.GetObject<User>("loggedUser") == null)
                return RedirectToAction("Index", "Home");

            this.HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            
        }
        
    }
    
}
