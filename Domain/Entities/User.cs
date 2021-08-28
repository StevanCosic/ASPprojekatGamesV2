using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new HashSet<UserFavorite>();
        public virtual ICollection<TitleReview> TitleReview { get; set; } = new HashSet<TitleReview>();
        public virtual ICollection<TitileRating> TitileRating { get; set; } = new HashSet<TitileRating>();
    }
}
