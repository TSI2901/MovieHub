using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieHub.Data
{
    public class MovieHubDbContext : IdentityDbContext
    {
        public MovieHubDbContext(DbContextOptions<MovieHubDbContext> options)
            : base(options)
        {
        }
    }
}