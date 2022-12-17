using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string user_Id { get; set; }
        public int genre_Id { get; set; }

        [ForeignKey(nameof(user_Id))]
        public Users User { get; set; }
    }
}
