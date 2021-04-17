using BlazorBattles.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
