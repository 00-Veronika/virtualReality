using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.Entities
{
    public class GameToType
    {  
       public int Id { get; set; }
       public int games_Id { get; set; }
       public int genre_Id { get; set; }

       [ForeignKey(nameof(games_Id))]

       public Games game { get; set; }

       [ForeignKey(nameof(genre_Id))]
       public Genre genre { get; set; }

    }
}
