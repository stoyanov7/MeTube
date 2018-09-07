namespace MeTube.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly MeTubeContext context;

        public DatabaseInitializerService(MeTubeContext context) => this.context = context;

        public void InitializeDatabase() => this.context.Database.Migrate();
    }
}
