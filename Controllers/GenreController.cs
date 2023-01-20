using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Helpers;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Controllers
{
    public class GenreController : Controller
    {
        private readonly MyDbContext _context;

        public GenreController(MyDbContext context)
        {
            _context = context;
        }

        // GET: GenreController/AllGenres
        [HttpGet]
        public IActionResult AllGenres()
        {
            var model = new AllGenresVM
            {
                Genres = _context.Genres.ToList()
            };

            return View(model);
        }

        // GET: GenreController/Create
        [HttpGet]
        public IActionResult Create()
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            return View();
        }

        // POST: GenreController/Create/{name}
        [HttpPost]
        public IActionResult Create(string name)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            var genreToCreate = new Genre()
            {
                Name = name
            };

            _context.Genres.Add(genreToCreate);
            _context.SaveChanges();

            return RedirectToAction("AllGenres", "Genre");
        }

        // GET: GenreController/Delete/{id}
        public IActionResult Delete(int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            var itemToDelete = _context.Genres
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                var associatedGenreForGames = _context.GamesInGenres
                    .Where(gig => gig.GenreId == id)
                    .ToList();

                _context.GamesInGenres.RemoveRange(associatedGenreForGames);
                _context.Genres.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("AllGenres", "Genre");
        }

        // GET: GenreController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            var itemToEdit = _context.Genres
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            var model = new GenreVM()
            {
                Id = itemToEdit.Id,
                Name = itemToEdit.Name
            };

            return View(model);
        }

        // POST: GenreController/Edit/{model}
        [HttpPost]
        public IActionResult Edit(GenreVM model)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var itemToEdit = _context.Genres
                .Where(g => g.Id == model.Id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            itemToEdit.Name = model.Name;

            _context.Genres.Update(itemToEdit);
            _context.SaveChanges();

            return RedirectToAction("AllGenres", "Genre");
        }
    }
}
