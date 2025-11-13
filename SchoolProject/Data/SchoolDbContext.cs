using Microsoft.EntityFrameworkCore;

namespace SchoolApi.SchoolProject.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Models.School> Schools => Set<Models.School>();

    }
}
