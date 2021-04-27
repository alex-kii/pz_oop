using Microsoft.EntityFrameworkCore;

namespace Web_Service.Models
{
    public class RestroomdbMainContext : DbContext
    {
        public RestroomdbMainContext()
        {
        }

        public DbSet<RestroomInfo> Place { get; set; }

        public RestroomdbMainContext(DbContextOptions<RestroomdbMainContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();           
        }
    }
}