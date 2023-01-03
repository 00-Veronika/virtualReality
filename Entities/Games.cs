using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.Entities
{
    public class Games
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string manufacturer { get; set; }
        public int releaseDate { get; set; }

    }
}
