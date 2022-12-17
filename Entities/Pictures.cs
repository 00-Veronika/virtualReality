using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.Entities
{
    public class Pictures
    {
        public int Id { get; set; }
        public string url { get; set; }
        public int games_Id { get; set; }

        [ForeignKey(nameof(game))]

        public Games game { get; set; }

    }
}
