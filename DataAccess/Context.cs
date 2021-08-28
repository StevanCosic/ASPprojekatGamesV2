using DataAccess.Confiurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=testGame;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DevsConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
           

            modelBuilder.Entity<TitileDevs>().HasKey(x => new { x.DevsId, x.TitileId });
            modelBuilder.Entity<TitileGenre>().HasKey(x => new { x.GenreId, x.TitileId });
            modelBuilder.Entity<TitileRating>().HasKey(x => new { x.UserId, x.TitileId });
            modelBuilder.Entity<UserFavorite>().HasKey(x => new { x.UserId, x.TitileId });

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.Active = true;
                            e.CreatedAt = DateTime.Now;
                            e.DeleteAt = null;
                            e.UpdateAt = null;
                            break;
                        case EntityState.Modified:
                            e.UpdateAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Titles> Title { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Devs> Devs { get; set; }
        public DbSet<TitileDevs> TitileDevs { get; set; }
        public DbSet<TitileGenre> TitileGenres { get; set; }
        public DbSet<TitleReview> TitleReviews { get; set; }
        public DbSet<TitileRating> TitileRatings { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
