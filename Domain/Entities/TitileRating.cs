using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TitileRating
    {
        public int UserId { get; set; }
        public int TitileId { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public Titles Titles { get; set; }
    }
}
