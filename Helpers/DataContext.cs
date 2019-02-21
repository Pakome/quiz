using Microsoft.EntityFrameworkCore;
using QuizGenerator.Entities;

namespace QuizGenerator.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}