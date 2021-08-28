using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Genre : Entity
    {
        public virtual ICollection<TitileGenre> TitileGenre { get; set; } = new HashSet<TitileGenre>();
    }
}
