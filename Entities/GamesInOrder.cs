using System.ComponentModel.DataAnnotations.Schema;

namespace virtualReality.Entities
{
    public class GamesInOrder
    {
        [ForeignKey(nameof(GameId))]
        public int GameId { get; set; }

        public int Id { get; set; }

        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
    }
}
