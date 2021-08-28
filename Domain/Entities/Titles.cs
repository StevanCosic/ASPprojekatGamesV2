using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Titles : Entity
    {
        public int Year { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
       public virtual ICollection<TitileGenre> TitileGenre { get; set; } = new HashSet<TitileGenre>();
        public virtual ICollection<TitileDevs> TitileDevs { get; set; } = new HashSet<TitileDevs>();
        public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new HashSet<UserFavorite>();
        public virtual ICollection<TitleReview> TitleReviews { get; set; } = new HashSet<TitleReview>();
        public virtual ICollection<TitileRating> TitileRatings { get; set; } = new HashSet<TitileRating>();
    }
}
