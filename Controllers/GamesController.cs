using System.IO;
using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Services.GameService;
using virtualReality.Services.OrderService;
using virtualReality.ViewModels.GamesVM;


namespace virtualReality.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameServices gameService;
        private readonly IOrderServices orderService;

        public GamesController(IGameServices gameServices , IOrderServices orderServices)
        {
            this.gameService = gameServices;
            this.orderService = orderServices;

        }

        public IActionResult AddToOrder(int id)
        {
            var getGame = gameService.GetGameById(id);
            var orderExists = orderService.GetOrderByGame(getGame);
            var getUserOrders = orderService.GetAllOrderForLoggedUser(HttpContext);
            var error = @"<script language='javascript'>alert('Product is already added to cart'); </script>";

            if (!getUserOrders.Any(x => x.UserId == orderExists.UserId))
            {
                gameService.AddToOrder(id);
                return RedirectToAction(nameof(ShowCustomerShoes)); // vij tui
            }
            else
            {
                return RedirectToAction(nameof(ShowCustomerShoes), "Games", new { error }); // vij tui
            }

        }

        // GET: GamesController/AllGames
        [HttpGet]
        public ActionResult AllGames()
        {
            var context = new MyDbContext();
            var games = context.Games.ToList();

            var model = new AllGamesVM
            {
                Items = games
            };

            return View(model);
        }

        // GET: GamesController/Create
        [HttpGet]
        public IActionResult Create()
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
            var model = new CreateVM();

            return View(model);
        }

        // POST: GamesController/Create
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
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

            return RedirectToAction("AllGames", "Games");
        }

        // DELETE: GamesController/Delete/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var context = new MyDbContext();
            Game itemToDelete = context.Games.Where(g => g.Id == id).FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Games.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllGames", "Games");
        }

        // GET: GamesController/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MyDbContext context = new MyDbContext();
            Game itemToEdit = context.Games.Where(g => g.Id == id).FirstOrDefault();

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
        public IActionResult Edit(EditGamesVM model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MyDbContext context = new MyDbContext();
            Game itemToEdit = context.Games.Where(g => g.Id == id).FirstOrDefault();

            itemToEdit.manufacturer = model.manufacturer;
            itemToEdit.releaseDate = model.releaseDate;
            itemToEdit.Genre = model.Genre;
            itemToEdit.Price = model.Price;
            itemToEdit.Name = model.Name;

            context.Games.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllGames", "Games");
        }
        public IActionResult ShowCustomerShoes(GamesVM gamemodel, string error)
        {

            gamemodel.OrderedGames = gameService.GetAllGames();
            foreach (var game in gamemodel.OrderedGames)
            {
                
                var GenreExists = gameService.GetTypeByGameVM(game).name;
                if (GenreExists != null)
                {
                    game.Genre = GenreExists;
                }
                else
                {
                    game.Genre = "None";
                }
                game.url = gameService.GetImageByGamesVM(game).url;
            }
            if (error != null)
            {
                HttpContext.Response.WriteAsync(error);
            }
            return View("AllGames", gamemodel);

        }
    }
}

