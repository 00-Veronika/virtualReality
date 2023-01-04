using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels.UsersVM;

namespace virtualReality.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            MyDbContext context = new MyDbContext();

            AllUsersVM model = new AllUsersVM();
            model.Items = context.Users.ToList();

            return View(model);
        }

        private IActionResult RadirectToAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            Users item = new Users();
            item.username = model.Username;
            item.password = model.Password;

            MyDbContext context = new MyDbContext();
            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Home", "Login");
        }
              [HttpGet]
              public IActionResult Edit(int id)
              {
                  MyDbContext context = new MyDbContext();
                  Users item = context.Users.FirstOrDefault(u => u.Id == id);

                  EditUsersVM model = new EditUsersVM();
                  model.Id = item.Id;
                  model.Username = item.username;
                  model.Password = item.password;

                  return View(model);
              }

              [HttpPost]
              public IActionResult Edit(EditUsersVM model)
              {
                  MyDbContext context = new MyDbContext();
                  Users item = context.Users.FirstOrDefault(u => u.Id == model.Id);

                  item.username = model.Username;
                  item.password = model.Password;

                  return RedirectToAction("Index", "Users");
              }

      

        public IActionResult Delete(int id)
        {
            MyDbContext context = new MyDbContext();
            Users item = new Users();
            item.Id = id;

            context.Users.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}
