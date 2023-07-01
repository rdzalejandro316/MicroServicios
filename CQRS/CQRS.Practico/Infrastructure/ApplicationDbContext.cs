using CQRS.Practico.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> taskItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

    }
}
