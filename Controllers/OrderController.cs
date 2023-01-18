using System.Linq;
using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using virtualReality.Entities;
using virtualReality.Extensions;
using virtualReality.ViewModels.OrdersVM;

namespace virtualReality.Controllers
{
    public class OrderController : Controller
    {
        private readonly MyDbContext _context;
        private readonly User _user;

        public OrderController(MyDbContext context)
        {
            _context = context;
            _user = HttpContext.Session.GetObject<User>("loggedUser");
        }

        // GET: OrderController/AllOrders
        [HttpGet]
        public IActionResult AllOrders()
        {
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            var model = new OrdersVM
            {
                UserRole = user.Role
            };

            // Return all if admin
            if (string.Equals(user.Role, "admin"))
            {
                model.Orders = _context.Orders.ToList();
            }
            else
            {
                model.Orders = _context.Orders
                    .Where(o => o.UserId == user.Id)
                    .ToList();
            }
            
            return View(model);
        }

        // GET: OrderController/Delete/{id}
        public IActionResult Delete(int id)
        {
            User user = HttpContext.Session.GetObject<User>("loggedUser");

            if (!string.Equals(user.Role, "admin"))
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
            User user = HttpContext.Session.GetObject<User>("loggedUser");

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
                GameId = currentOrder.GameId,
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

            User user = HttpContext.Session.GetObject<User>("loggedUser");

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

        private IActionResult RedirectIfNotUser()
        {
            if (!string.Equals(_user.Role, "admin"))
            {
                return RedirectToAction("AllOrders", "Order");
            }

            return Ok();
        }
    }
}
