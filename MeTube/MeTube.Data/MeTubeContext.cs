namespace MeTube.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MeTubeContext : IdentityDbContext<ApplicationUser>
    {
        public MeTubeContext()
        {
        }

        public MeTubeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Tube> Tubes { get; set; }
    }
}
