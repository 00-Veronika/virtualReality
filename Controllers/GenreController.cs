using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenreController/AllGenres
        [HttpGet]
        public IActionResult AllGenres()
        {
            var context = new MyDbContext();
            var genres = context.Genres.ToList();

            var model = new AllGenresVM
            {
                Genres = genres
            };

            return View(model);
        }

        // GET: GenreController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create/{name}
        [HttpPost]
        public IActionResult Create(string name)
        {
            var context = new MyDbContext();
            var genreToCreate = new Genre()
            {
                Name = name
            };

            context.Genres.Add(genreToCreate);
            context.SaveChanges();

            return RedirectToAction("AllGenres", "Genre");
        }

        // DELETE: GenreController/Delete/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var context = new MyDbContext();
            Genre itemToDelete = context.Genres
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Genres.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllGenres", "Genre");
        }

        // GET: GenreController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = new MyDbContext();
            Genre itemToEdit = context.Genres
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var context = new MyDbContext();
            Genre itemToEdit = context.Genres
                .Where(g => g.Id == model.Id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            itemToEdit.Name = model.Name;

            context.Genres.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllGenres", "Genre");
        }
    }
}
