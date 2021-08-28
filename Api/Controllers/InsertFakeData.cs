using Bogus;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertFakeData : ControllerBase
    {
        // POST api/<InsertFakeData>
        [HttpPost]
        public IActionResult Post()
        {
            var _context = new Context(); 

            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin"
                }, new Role
                {
                    Name = "User"
                }
            };

            var usersFaker = new Faker<User>();
            usersFaker.RuleFor(x => x.Name, f => f.Name.FirstName());
            usersFaker.RuleFor(x => x.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(x => x.Username, f => f.Internet.UserName());
            usersFaker.RuleFor(x => x.Email, f => f.Internet.Email());
            usersFaker.RuleFor(x => x.Password, f => "test1");
            usersFaker.RuleFor(x => x.Role, f => f.PickRandom(roles));
            

            var users = usersFaker.Generate(10);

            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Action"
                },
                new Genre
                {
                    Name = "FPS"
                },new Genre
                {
                    Name = "Horor"
                },
                new Genre
                {
                    Name = "RPG"
                },
                new Genre
                {
                    Name = "Strategy"
                },
                 new Genre
                {
                    Name = "Racing"
                }
            };


            var DevssFaker = new Faker<Devs>();
            DevssFaker.RuleFor(x => x.Name, f => f.Name.FirstName());
           

            var Devss = DevssFaker.Generate(20);
            Random r = new Random();
            var titles = new List<Titles>
            {
                new Titles
                {
                    Name = "Fallout",
                    Description = "Opis",
                    Year = 2012,
                    Link = "link1",
                    Image = "img1.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    TitleReviews = new List<TitleReview>
                    {
                        new TitleReview
                        {
                            User = users.First(),
                            Review = "Best game that i ever played",
                            ReviewDate = DateTime.Now
                        }
                    }

                },
                new Titles
                {
                    Name = "Dirt 2",
                    Description = "Opis",
                   
                    Year = 2016,
                    Link = "link2",
                    Image = "img2.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Titles
                {
                    Name = "Call of duty",
                    Description = "Opis",
                    
                    Year = 2003,
                    Link = "link3",
                    Image = "img3.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    TitleReviews = new List<TitleReview>
                    {
                        new TitleReview
                        {
                            User = users.Last(),
                            Review = "Best Game ever made",
                            ReviewDate = DateTime.Now
                        }
                    }

                },
                new Titles
                {
                    Name = "Doom Etarnal",
                    Description = "Opis",
                   
                    Year = 2020,
                    Link = "link4",
                    Image = "img4.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    UserFavorites = new List<UserFavorite>
                    {
                        new UserFavorite
                        {
                            User = users.First()
                        },
                        new UserFavorite
                        {
                            User = users.Last()
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 5",
                    Description = "Opis",
                   
                    Year = 2018,
                    Link = "link5",
                    Image = "img5.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 6",
                    Description = "Opis",
                    
                    Year = 2014,
                    Link = "link6",
                    Image = "img6.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    UserFavorites = new List<UserFavorite>
                    {
                        new UserFavorite
                        {
                            User = users.Last()
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 7",
                    Description = "Opis",
                    
                    Year = 2015,
                    Link = "link7",
                    Image = "img7.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 8",
                    Description = "Opis",
                  
                    Year = 2015,
                    Link = "link8",
                    Image = "img8.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 9",
                    Description = "Opis",
                    
                    Year = 2010,
                    Link = "link9",
                    Image = "img9.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Titles
                {
                    Name = "Game 10",
                    Description = "Opis",
                   
                    Year = 2008,
                    Link = "link10",
                    Image = "img10.jpg",
                    TitileDevs = new List<TitileDevs>
                    {
                        new TitileDevs
                        {
                            Devs = Devss.First()
                        },
                        new TitileDevs
                        {
                            Devs = Devss.Last()
                        }
                    },
                    TitileGenre = new List<TitileGenre>
                    {
                        new TitileGenre
                        {
                            Genre = genres.First()
                        },
                        new TitileGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    TitileRatings = new List<TitileRating>
                    {
                        new TitileRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new TitileRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                }
            };

            _context.Users.AddRange(users);
            _context.Devs.AddRange(Devss);
            _context.Genres.AddRange(genres);
            _context.Title.AddRange(titles);
           
            
                _context.SaveChanges();
                return StatusCode(201);
            
         
        }

    }
}
