using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels.GenreVM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace virtualReality.Controllers
{
    public class GenreController : Controller
    {
        public ActionResult AllGenres(GenreVM model)
        {

            MyDbContext context = new MyDbContext();

            model.Items = context.Genres.ToList();

            //foreach (var genre in model.Items)
            //{
            //    model.Items = context.GameToTypes.Where(i => i.genre_Id == genre.Id).Select(x => x.genre).ToList();
            //}

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GenreVM model = new GenreVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(GenreVM model)
        {
            MyDbContext context = new MyDbContext();
            var genreToCreate = new Genre()
            {
                name = model.Name
            };

            context.Genres.Add(genreToCreate);
            context.SaveChanges();
            return RedirectToAction("AllGenres", "Genre");
        }

        public IActionResult Delete(int id)
        {
            MyDbContext context = new MyDbContext();
            Genre itemToDelete = context.Genres.Where(g => g.Id == id).FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Genres.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllGenres", "Genre");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            MyDbContext context = new MyDbContext();
            Genre itemToEdit = context.Genres.Where(g => g.Id == id).FirstOrDefault();
            //itemToEdit = null;

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            GenreVM model = new GenreVM();
            model.Id = itemToEdit.Id;
            model.Name = itemToEdit.name;

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(GenreVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MyDbContext context = new MyDbContext();
            Genre itemToEdit = context.Genres.Where(g => g.Id == model.Id).FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGenres", "Genre");
            }

            itemToEdit.Id = model.Id;
            itemToEdit.name = model.Name;

            context.Genres.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllGenres", "Genre");
        }
    }
}
