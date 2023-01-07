using EntityFrameworkSample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult AllGenres(GenreVM model) { 
            
            MyDbContext context = new MyDbContext();

            model.Items = context.Genre.ToList();

            foreach (var genre in model.Items)
            {
                model.Items = context.GameToTypes.Where(i => i.genre_Id == genre.Id).Select(x => x.genre).ToList();
            }

            return View();
        }
    }
}
