using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using virtualReality.Entities;

namespace virtualReality.ViewModels.GamesVM
{
    public class CreateVM
    {
        [Required(ErrorMessage = nameof(Genres) + FieldConstants.REQUIRED)]
        public IEnumerable<Genre> Genres { get; set; }
        
        [Required(ErrorMessage = nameof(SelectedGenreIds) + FieldConstants.REQUIRED)]
        public List<int> SelectedGenreIds { get; set; }

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
