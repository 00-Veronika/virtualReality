using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.ViewModels.GamesVM;

namespace virtualReality.Controllers
{
    public class GameController : Controller
    {
        private readonly MyDbContext _context;

        public GameController(MyDbContext context)
        {
            _context = context;
        }

        // GET: GameController/AllGames
        [HttpGet]
        public IActionResult AllGames()
        {
            var model = new AllGamesVM
            {
                Games = _context.Games.ToList()
            };

            return View(model);
        }

        // GET: GameController/AllGames/{genreId}
        [HttpGet("Game/AllGames/{genreId}")]
        public IActionResult AllGames(int genreId)
        {
            var gameIds = _context.GamesInGenres
                .Where(x => x.GenreId == genreId)
                .Select(gig => gig.GameId)
                .ToList();

            var games = _context.Games
                .Where(game => gameIds.Contains(game.Id))
                .ToList();

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
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
            {
                return RedirectToAction("AllGames", "Game");
            }

            var model = new CreateVM
            {
                Genres = _context.Genres.ToList()
            };

            return View(model);
        }

        // POST: GameController/Create
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
            {
                return RedirectToAction("AllGames", "Game");
            }

            var item = new Game
            {
                Name = model.Name,
                Price = model.Price,
                Manufacturer = model.Manufacturer,
                ReleaseDate = model.ReleaseDate,
                Url = model.Url
            };

            _context.Games.Add(item);
            _context.SaveChanges();

            var id = item.Id;
            var listToAdd = new List<GamesInGenre>();

            foreach (var gId in model.SelectedGenreIds)
            {
                listToAdd.Add(
                    new GamesInGenre
                    {
                        GameId = id,
                        GenreId = gId
                    }
                );
            }

            _context.GamesInGenres.AddRange(listToAdd);
            _context.SaveChanges();

            return RedirectToAction("AllGames", "Game");
        }

        // GET: GameController/Delete/{id}
        public IActionResult Delete(int id)
        {
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
            {
                return RedirectToAction("AllGames", "Game");
            }

            var itemToDelete = _context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                var associatedGameForGenres = _context.GamesInGenres
                    .Where(gig => gig.GameId == id)
                    .ToList();

                _context.GamesInGenres.RemoveRange(associatedGameForGenres);
                _context.Games.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("AllGames", "Game");
        }

        // GET: GameController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
            {
                return RedirectToAction("AllGames", "Game");
            }

            var itemToEdit = _context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllGames", "Game");
            }

            var availableGenres = _context.Genres.ToList();

            var selectedIds = _context.GamesInGenres
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
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
            {
                return RedirectToAction("AllGames", "Game");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var itemToEdit = _context.Games
                .Where(g => g.Id == id)
                .FirstOrDefault();

            itemToEdit.Manufacturer = model.Manufacturer;
            itemToEdit.ReleaseDate = model.ReleaseDate;
            itemToEdit.Price = model.Price;
            itemToEdit.Name = model.Name;
            itemToEdit.Url = model.Url;

            var listToAdd = new List<GamesInGenre>();
            var genresToDecouple = _context.GamesInGenres
                .Where(gig => gig.GameId == id)
                .ToList();

            _context.GamesInGenres.RemoveRange(genresToDecouple);

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

            _context.GamesInGenres.AddRange(listToAdd);

            _context.Games.Update(itemToEdit);
            _context.SaveChanges();

            return RedirectToAction("AllGames", "Game");
        }
    }
}

