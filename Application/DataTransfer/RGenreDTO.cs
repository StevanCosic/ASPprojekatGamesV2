using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class RGenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GameDevsGenDto> GameDevsGens { get; set; } = new List<GameDevsGenDto>();
    }
}
