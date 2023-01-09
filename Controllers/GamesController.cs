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

        public IActionResult Delete(int id)
        {
            MyDbContext context = new MyDbContext();
            Games itemToDelete = context.Games.Where(g => g.Id == id).FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Games.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllGames", "Games");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            MyDbContext context = new MyDbContext();
            Games itemToEdit = context.Games.Where(g => g.Id == id).FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGames", "Games");
            }

            EditGamesVM model = new EditGamesVM();
            model.Id = itemToEdit.Id;
            model.manufacturer = itemToEdit.manufacturer;
            model.releaseDate = itemToEdit.releaseDate;
            model.Genre = itemToEdit.Genre;
            model.Price = itemToEdit.Price;
            model.Name = itemToEdit.Name;

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(EditGamesVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MyDbContext context = new MyDbContext();
            Games itemToEdit = context.Games.Where(g => g.Id == model.Id).FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGames", "Games");
            }

            model.Id = itemToEdit.Id;
            model.manufacturer = itemToEdit.manufacturer;
            model.releaseDate = itemToEdit.releaseDate;
            model.Genre = itemToEdit.Genre;
            model.Price = itemToEdit.Price;
            model.Name = itemToEdit.Name;

            context.Games.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllGames", "Games");
        }
    }
}
