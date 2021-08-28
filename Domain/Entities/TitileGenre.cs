using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TitileGenre
    {
        public int TitileId { get; set; }
        public int GenreId { get; set; }

        public Titles title { get; set; }
        public Genre Genre { get; set; }
    }
}
