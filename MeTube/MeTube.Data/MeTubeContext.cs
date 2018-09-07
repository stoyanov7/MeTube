namespace MeTube.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MeTubeContext : DbContext
    {
        public MeTubeContext()
        {
        }

        public MeTubeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tube> Tubes { get; set; }
    }
}
