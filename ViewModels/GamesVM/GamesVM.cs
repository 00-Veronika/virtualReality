using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;

namespace virtualReality.ViewModels.GamesVM
{
    public class GamesVM
    {
        public List<Games> Items { get; set; }
        public List<Genre> Genres { get; set; }
        public string Name { get; set; }
        public string  Genre { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public int ReleaseDate { get; set; }
    }
}
