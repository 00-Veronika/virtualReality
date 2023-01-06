using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;

namespace virtualReality.ViewModels.GamesVM
{
    public class AllGamesVM
    {
        public List<Games> Items { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
