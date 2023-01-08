using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Controllers
{
    public class GenreController : Controller
    {
        public ActionResult AllGenres(GenreVM model)
        {

            MyDbContext context = new MyDbContext();

            model.Items = context.Genre.ToList();

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

            context.Genre.Add(genreToCreate);
            context.SaveChanges();
            return RedirectToAction("AllGenres", "Genre");
        }
    }
}
