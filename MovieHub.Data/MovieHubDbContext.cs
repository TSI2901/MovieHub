using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieHub.Data.Models;

namespace MovieHub.Data;

public class MovieHubDbContext : IdentityDbContext<IdentityUser>
{
    public MovieHubDbContext(DbContextOptions<MovieHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Director> Directors { get; set; } = null!;
    public DbSet<Studio> Studios { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Reward> Rewards { get; set; } = null!;
    public DbSet<MovieActor> MoviesActors { get; set; } = null!;
    public DbSet<MovieCategory> MoviesCategories { get; set; } = null!;
    public DbSet<MovieDirector> MoviesDirectors { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieActor>(x =>
        {
            x.HasKey(x => new { x.MovieId, x.ActorId });
        });
        modelBuilder.Entity<MovieDirector>(x =>
        {
            x.HasKey(x => new { x.MovieId, x.DirectorId });
        });
        modelBuilder.Entity<MovieCategory>(x =>
        {
            x.HasKey(x => new { x.MovieId, x.CategoryId });
        });

        modelBuilder.Entity<Movie>()
            .Property(m => m.Budget)
            .HasColumnType("decimal(18, 2)");

        modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Action"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Comedy"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Adventure"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Drama"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Romance"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Horror"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Thriller"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Science Fiction"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Fantasy"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Animation"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Musical"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Historical"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "War"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Western"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mystery"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Documentary"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sports"

                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Biographical"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Musical Comedy"

                });

        modelBuilder
               .Entity<Reward>()
               .HasData(new Reward()
               {
                   Id = Guid.NewGuid(),
                   Title = "Oscar"
               },
               new Reward()
               {
                   Id = Guid.NewGuid(),
                   Title = "Golden Globe"
               },
               new Reward()
               {
                   Id = Guid.NewGuid(),
                   Title = "BAFTA"
               },
               new Reward()
               {
                   Id = Guid.NewGuid(),
                   Title = "Palme d'Or"
               },
               new Reward()
               {
                   Id = Guid.NewGuid(),
                   Title = "Golden Bear"
               });



       base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("DefaultConnection", b => b.MigrationsAssembly("MovieHub.Data"));
        }
    }
}
