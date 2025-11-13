using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<SchoolApi.Models.School> Schools => Set<SchoolApi.Models.School>();

    }
}
