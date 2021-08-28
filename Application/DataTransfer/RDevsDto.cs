using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class RDevsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public IEnumerable<GameDevsGenDto> GameDevsGenDto { get; set; } = new List<GameDevsGenDto>();
    }

    public class GameDevsGenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
