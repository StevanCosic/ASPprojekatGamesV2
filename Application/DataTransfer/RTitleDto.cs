using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class RTitleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public int Year { get; set; }
        public string link { get; set; }
        public string Image { get; set; }
         public string? Rating { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public IEnumerable<DevsDto> Devs { get; set; } = new List<DevsDto>();
        public IEnumerable<ReviewCommandDto> Reviews { get; set; } = new List<ReviewCommandDto>();
    }

    public class ReviewCommandDto
    {
        public string UserName { get; set; }
        public string Reviews { get; set; }
        public DateTime Date { get; set; }
    }
}
