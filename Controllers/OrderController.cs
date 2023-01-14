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
        // GET: OrderController/AllOrders
        [HttpGet]
        public IActionResult AllOrders()
        {
            var context = new MyDbContext();
            var orders = context.Orders.ToList();

            var model = new OrdersVM
            {
                Orders = orders
            };

            return View(model);
        }

        // GET: OrderController/AllUserOrders
        [HttpGet]
        public IActionResult AllUserOrders()
        {
            var context = new MyDbContext();
            var id = HttpContext.Session.GetObject<User>("loggedUser").Id;
            var userOrders = context.Orders
                .Where(o => o.UserId == id)
                .ToList();

            var model = new OrdersVM
            {
                Orders = userOrders
            };

            return View(model);
        }

        // DELETE: OrderController/Delete/{id}
        public IActionResult Delete(int id)
        {
            var context = new MyDbContext();
            Order itemToDelete = context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Orders.Remove(itemToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("AllUserOrders", "Order");
        }

        // GET: OrderController/EditStatus
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            var context = new MyDbContext();
            var currentOrder = context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

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

            var context = new MyDbContext();
            Order itemToEdit = context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            itemToEdit.Status = model.Status;

            context.Orders.Update(itemToEdit);
            context.SaveChanges();

            return RedirectToAction("AllUserOrders", "Order");
        }
    }
}
