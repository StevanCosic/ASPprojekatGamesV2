using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TitileDevs
    {
        public int TitileId { get; set; }
        public int DevsId { get; set; }
        public Titles Titles { get; set; }
        public Devs Devs { get; set; }
    }
}
