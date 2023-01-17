using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.ViewModels.GamesVM;
using System.Text.Json;

namespace virtualReality.Controllers
{
    public class GameController : Controller
    {
        // GET: GameController/AllGames
        [HttpGet]
        public ActionResult AllGames()
        {
            var context = new MyDbContext();
            var games = context.Games.ToList();

            var model = new AllGamesVM
            {
                Games = games
            };

            return View(model);
        }

        // GET: GameController/Create
        [HttpGet]
        public IActionResult Create()
        {
            var context = new MyDbContext();
            var availableGenres = context.Genres.ToList();

            var model = new CreateVM
            {
                Genres = availableGenres
            };

            return View(model);
        }

        // POST: GameController/Create
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            var context = new MyDbContext();
            var item = new Game
            {
                Name = model.Name,
                Price = model.Price,
                Manufacturer = model.Manufacturer,
                ReleaseDate = model.ReleaseDate,
                Url = model.Url
            };

            context.Games.Add(item);
            context.SaveChanges();

            var id = item.Id;
            var listToAdd = new List<GamesInGenre>();

            foreach (var gId in model.SelectedGenreIds)
            {
                listToAdd.Add(
                    new GamesInGenre
                    {
                        GameId = id,
                        GenreId = gId,
                    }
                );
            }

            context.GamesInGenres.AddRange(listToAdd);
            context.SaveChanges();

            return RedirectToAction("AllGames", "Game");
        }

        // DELETE: GameController/Delete/{id}
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            var context = new MyDbContext();
            Game itemToDelete = context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                // Delete associated genres!

                context.Games.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllGames", "Game");
        }

        // GET: GameController/Details
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        // GET: GameController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = new MyDbContext();
            Game itemToEdit = context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGames", "Game");
            }

            var availableGenres = context.Genres.ToList();

            var selectedIds = context.GamesInGenres
                .Where(gig => gig.GameId == id)
                .Select(g => g.GenreId)
                .ToList();

            var model = new EditGamesVM()
            {
                Id = itemToEdit.Id,
                Genres = availableGenres,
                Manufacturer = itemToEdit.Manufacturer,
                ReleaseDate = itemToEdit.ReleaseDate,
                Price = itemToEdit.Price,
                Name = itemToEdit.Name,
                Url = itemToEdit.Url,
                SelectedGenreIds = selectedIds
            };

            return View(model);
        }

        // POST: GameController/Edit?id={id}
        [HttpPost]
        public IActionResult Edit(EditGamesVM model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var context = new MyDbContext();
            Game itemToEdit = context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            itemToEdit.Manufacturer = model.Manufacturer;
            itemToEdit.ReleaseDate = model.ReleaseDate;
            itemToEdit.Price = model.Price;
            itemToEdit.Name = model.Name;

            var listToAdd = new List<GamesInGenre>();
            var genresToDecouple = context.GamesInGenres
                .Where(gig => gig.GameId == id)
                .ToList();

            context.GamesInGenres.RemoveRange(genresToDecouple);

            foreach (var gId in model.SelectedGenreIds)
            {
                listToAdd.Add(
                    new GamesInGenre
                    {
                        GameId = id,
                        GenreId = gId,
                    }
                );
            }

            context.GamesInGenres.AddRange(listToAdd);

            context.Games.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllGames", "Game");
        }
    }
}

