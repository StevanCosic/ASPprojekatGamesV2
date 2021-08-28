using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Devs : Entity
    {
        
        public virtual ICollection<TitileDevs> TitileDevs { get; set; } = new HashSet<TitileDevs>();
    }
}
