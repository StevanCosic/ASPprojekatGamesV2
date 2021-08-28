using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TitleReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TitileId { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
        public User User { get; set; }
        public Titles titles { get; set; }
    }
}
