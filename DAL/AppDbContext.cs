using Eduhomee.Models;
using Microsoft.EntityFrameworkCore;

namespace Eduhomee.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> sliders { get; set; }
        public DbSet<Board> boards { get; set; }
        public DbSet<EventBoard> eventBoards { get; set; }
        public DbSet<Engineering> engineerings { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Event> events { get; set; }
    }
}
