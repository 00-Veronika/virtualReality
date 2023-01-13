using System.ComponentModel.DataAnnotations.Schema;

namespace virtualReality.Entities
{
    public class Picture
    {
        [ForeignKey(nameof(GameId))]
        public int GameId { get; set; }

        public int Id { get; set; }
        public string Url { get; set; }
    }
}
