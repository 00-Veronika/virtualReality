using System;
using System.ComponentModel.DataAnnotations;

namespace virtualReality.ViewModels.GamesVM
{
    public class EditGamesVM
    {
        [Required(ErrorMessage = nameof(Genre) + FieldConstants.REQUIRED)]
        public string Genre { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = nameof(Manufacturer) + FieldConstants.REQUIRED)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = nameof(Name) + FieldConstants.REQUIRED)]
        public string Name { get; set; }

        [Required(ErrorMessage = nameof(Price) + FieldConstants.REQUIRED)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = nameof(ReleaseDate) + FieldConstants.REQUIRED)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = nameof(Url) + FieldConstants.REQUIRED)]
        public string Url { get; set; }
    }
}
