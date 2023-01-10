using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using virtualReality.Services.GameService;
using virtualReality.Services.OrderService;
using virtualReality.ViewModels.GamesVM;

namespace virtualReality.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices  _orderServices;
        private readonly IGameServices _gamesServices;

        public OrderController(IOrderServices orderServices, IGameServices gamesServices)
        {
            _orderServices = orderServices;
            _gamesServices = gamesServices;
        }

        public IActionResult AllUserOrders(GamesVM allOrderedGames)
        {
            allOrderedGames.UserOrderedGames = _orderServices.GetUserOrderedGames();
            return View(allOrderedGames);
        }

        public IActionResult AllOrders(GamesVM allOrderedGames)
        {
            allOrderedGames.OrderedGames = _orderServices.GetAllOrderedGamesVM();
            return View(allOrderedGames);
        }

        [HttpGet]
        public IActionResult EditStatus(GamesVM game, int Id)
        {
            var getCurrOrder = _orderServices.GetOrderByUserId(Id);
            game.Status = getCurrOrder.Status;
            game.userId = getCurrOrder.user_Id;
            game.Id = getCurrOrder.Game_Id;
            return View(game);
        }

        [HttpPost]
        public IActionResult EditStatus(string Status)
        {
            List<string> value = Status.Split("+").ToList();

            if (ModelState.IsValid)
            {
                _orderServices.Edit(0, " ");
            }

            return RedirectToAction(nameof(AllOrders));
        }

        public IActionResult Delete(int id)
        {
            _orderServices.Delete(id);
            return RedirectToAction(nameof(AllUserOrders));
        }
    }
}

