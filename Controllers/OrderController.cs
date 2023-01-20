using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.Helpers;
using virtualReality.ViewModels.OrdersVM;
using virtualReality.ViewModels;
using System.Collections.Generic;

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

                    var gamesForOrder = _context.Games
                        .Where(g => g.Id == order.GameId)
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
                    var gamesForOrder = _context.Games
                        .Where(g => g.Id == userOrder.GameId)
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

        // GET: OrderController/Create/{id}
        public IActionResult Create(int gameId)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");
            var ordered = Enums.OrderStatus.Ordered.ToString();

            var order = new Order
            {
                GameId = gameId,
                UserId = user.Id,
                Status = ordered
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("AllOrders", "Order");
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
                _context.Orders.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("AllOrders", "Order");
        }

        // GET: OrderController/EditStatus
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            var user = HttpContext.Session.GetObject<User>("loggedUser");

            var currentOrder = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (currentOrder == null)
            {
                return RedirectToAction("AllOrders", "Order");
            }
            else if (!int.Equals(user.Id, currentOrder.UserId))
            {
                return RedirectToAction("AllOrders", "Order");
            }

            var model = new OrderVM
            {
                Id = id,
                UserId = currentOrder.UserId,
                Status = currentOrder.Status
            };

            return View(model);
        }

        // POST: OrderController/EditStatus
        [HttpPost]
        public IActionResult EditStatus(OrderVM model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = HttpContext.Session.GetObject<User>("loggedUser");

            var itemToEdit = _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (itemToEdit == null)
            {
                return RedirectToAction("AllOrders", "Order");
            }
            else if (!int.Equals(user.Id, itemToEdit.UserId))
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
