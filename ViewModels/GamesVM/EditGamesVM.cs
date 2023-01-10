using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace virtualReality.ViewModels.GamesVM
{
    public class EditGamesVM
    {
        [Required(ErrorMessage = "*This field is required!")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public string manufacturer { get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public int releaseDate { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public decimal Price{ get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public string url { get; set; }
    }
}
