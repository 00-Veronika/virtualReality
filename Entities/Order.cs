using System.ComponentModel.DataAnnotations.Schema;

namespace virtualReality.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
    }
}
