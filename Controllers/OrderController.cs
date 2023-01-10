using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Services.OrderService;
using virtualReality.Services.GameService;
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
            allOrderedGames.UserOrderedGames = _orderServices.getUserOrderedGames();
            return View(allOrderedGames);
        }

        public IActionResult AllOrders(GamesVM allOrderedGames)
        {
            allOrderedGames.OrderedGames = _orderServices.Get_All_Ordered_GamesVM();
            return View(allOrderedGames);
        }

        [HttpGet]
        public IActionResult EditStatus(GamesVM game, string Id)
        {
            var getCurrOrder = _orderServices.getOrderByUserId(Id);
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
                _orderServices.Edit(value[1], value[0]);
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

