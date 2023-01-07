using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;

namespace virtualReality.ViewModels.GamesVM
{
    public class CreateVM
    {
        public List<Genre> Genres { get; set; }
        public List<Games> Games { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public int ReleaseDate { get; set; }
    }
}
