using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Helpers;
using virtualReality.ViewModels.OrdersVM;
using static virtualReality.ViewModels.Enums;

namespace virtualReality.Controllers
{
    public class OrderController : Controller
    {
        private readonly MyDbContext _context;

        public OrderController(MyDbContext context)
        {
            _context = context;
        }

        // GET: OrderController/AllOrders
        [HttpGet]
        public IActionResult AllOrders()
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            var model = new OrdersVM
            {
                UserRole = user.Role
            };


            // Return all if admin
            if (isAdmin)
            {
                var allOrders = _context.Orders.ToList();

                foreach (var order in allOrders)
                {
                    var customer = _context.Users
                        .Where(u => u.Id == order.UserId)
                        .Select(x => new { x.FirstName, x.LastName })
                        .FirstOrDefault();

                    var customerFullName = $"{customer.FirstName} {customer.LastName}";

                    var gamesInOrder = _context.GamesInOrders
                        .Where(gio => gio.OrderId == order.Id)
                        .Select(x => x.GameId)
                        .ToList();

                    var gamesForOrder = _context.Games
                        .Where(g => gamesInOrder.Contains(g.Id))
                        .ToList();

                    model.Orders.Add(new OrderVM
                        {
                            Id = order.Id,
                            Status = order.Status,
                            UserId = order.UserId,
                            UserFullName = customerFullName,
                            Games = gamesForOrder
                        }
                    );
                }
            }
            else
            {
                var fullName = $"{user.FirstName} {user.LastName}";
                var allUserOrders = _context.Orders
                    .Where(o => o.UserId == user.Id)
                    .ToList();

                foreach (var userOrder in allUserOrders)
                {
                    var gamesInOrder = _context.GamesInOrders
                        .Where(gio => gio.OrderId == userOrder.Id)
                        .Select(x => x.GameId)
                        .ToList();

                    var gamesForOrder = _context.Games
                        .Where(g => gamesInOrder.Contains(g.Id))
                        .ToList();

                    model.Orders.Add(new OrderVM
                        {
                            Id = userOrder.Id,
                            Status = userOrder.Status,
                            UserId = userOrder.UserId,
                            UserFullName = fullName,
                            Games = gamesForOrder
                        }
                    );
                }
            }

            return View(model);
        }

        public IActionResult CreateBundle(int[] ids)
        {
            if (ids?.Length == 0)
            {
                return RedirectToAction("AllGames", "Game");
            }

            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (isAdmin)
            {
                return RedirectToAction("AllGames", "Game");
            }

            var ordered = OrderStatus.Ordered.ToString();
            var order = new Order
            {
                Status = ordered,
                UserId = user.Id
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            var orderId = order.Id;
            var listOfOrders = new List<GamesInOrder>();

            foreach (var id in ids)
            {
                listOfOrders.Add(
                    new GamesInOrder
                    {
                        OrderId = orderId,
                        GameId = id
                    }
                );
            }

            _context.GamesInOrders.AddRange(listOfOrders);
            _context.SaveChanges();

            return Ok();
        }

        // GET: OrderController/Delete/{id}
        public IActionResult Delete(int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var itemToDelete = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                var associatedOrderForGames = _context.GamesInOrders
                    .Where(gio => gio.OrderId == id)
                    .ToList();

                _context.GamesInOrders.RemoveRange(associatedOrderForGames);
                _context.Orders.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("AllOrders", "Order");
        }

        // GET: OrderController/EditStatus
        [HttpGet]
        public IActionResult CancelOrder(int id)
        {
            var currentOrder = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            var itemToEdit = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!int.Equals(user.Id, itemToEdit.UserId))
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var cancelled = OrderStatus.Cancelled.ToString();
            itemToEdit.Status = cancelled;

            _context.Update(itemToEdit);
            _context.SaveChanges();

            return RedirectToAction("AllOrders", "Order");
        }

        // GET: OrderController/EditStatus
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var currentOrder = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (currentOrder == null)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var model = new EditOrderVM
            {
                Id = id,
                Status = currentOrder.Status
            };

            return View(model);
        }

        // POST: OrderController/EditStatus
        [HttpPost]
        public IActionResult EditStatus(OrderVM model, int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var isAdmin = Utilities.IsUserAdmin(user.Role);

            if (!isAdmin)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var itemToEdit = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllOrders", "Order");
            }

            itemToEdit.Status = model.Status;

            _context.Orders.Update(itemToEdit);
            _context.SaveChanges();

            return RedirectToAction("AllOrders", "Order");
        }
    }
}
