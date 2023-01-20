using System.Collections.Generic;
using virtualReality.Entities;

namespace virtualReality.ViewModels.OrdersVM
{
    public class OrderVM
    {
        public List<Game> Games { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public string UserFullName { get; set; }
        public int UserId { get; set; }
        public decimal Total
        {
            get
            {
                decimal total = 0;

                foreach (var game in Games)
                {
                    total += game.Price;
                }

                return total;
            }
        }
    }
}
