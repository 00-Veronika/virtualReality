using System.Collections.Generic;
using virtualReality.Entities;

namespace virtualReality.ViewModels.GamesVM
{
    public class GamesVM
    {
        public int Id { get; set; }
        public List<Games> Items { get; set; }
        public List<Genre> Genres { get; set; }
        public string Name { get; set; }
        public string  Genre { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public int ReleaseDate { get; set; }

        public string url { get; set; }
        public Orders order { get; set; }
        public int userId { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }

        public IEnumerable<GamesVM> OrderedGames { get; set; }
        public IEnumerable<GamesVM> UserOrderedGames { get; set; }
    }
}
