using System;
using System.ComponentModel.DataAnnotations;

namespace virtualReality.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Url { get; set; }
    }
}
