using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class TitleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Link { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile CoverImage { get; set; }

      
        public ICollection<TitileGenreDto> genres { get; set; } = new List<TitileGenreDto>();
        public ICollection<TitileDevDto> devs { get; set; } = new List<TitileDevDto>();
    }

    public class TitileDevDto
    {
        public int DevId { get; set; }
    }

    public class TitileGenreDto
    {
        public int GenreId { get; set; }
    }

}
