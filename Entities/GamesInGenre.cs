using System.ComponentModel.DataAnnotations.Schema;

namespace virtualReality.Entities
{
    public class GamesInGenre
    {
        [ForeignKey(nameof(GameId))]
        public int GameId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public int GenreId { get; set; }

        public int Id { get; set; }
    }
}
