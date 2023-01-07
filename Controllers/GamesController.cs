using EntityFrameworkSample;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.ViewModels.GamesVM;


namespace virtualReality.Controllers
{
    public class GamesController : Controller
    {
        // GET: GamesController
        public ActionResult AllGames(AllGamesVM model)
        {
            MyDbContext context = new MyDbContext();

            model.Items = context.Games.ToList();

            foreach (Games game in model.Items)
            {
                model.Genres = context.GameToTypes.Where(i => i.games_Id == game.Id).Select(x => x.genre).ToList();
            }


            return View(model);
        }

        // GET: GamesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");

            CreateVM model = new CreateVM();
           
            return View(model);
        }


        // POST: GamesController/Create
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
          
            MyDbContext context = new MyDbContext();

            Games item = new Games();
            item.Name = model.Name;
            item.Genre = model.Genre;
            item.Price = model.Price;
            item.manufacturer = model.Manufacturer;
            item.releaseDate = model.ReleaseDate;

            context.Games.Add(item);
            context.SaveChanges();

            return RedirectToAction("AllGames", "Games");
        }

        // GET: GamesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GamesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GamesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GamesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
