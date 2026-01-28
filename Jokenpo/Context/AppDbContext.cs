using Jokenpo.Models;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options) 
        {
            
        }

        public DbSet<Player> Players {get; set;}
        
    }
}