using Microsoft.EntityFrameworkCore;
using TinyProjectModels.Entities;

namespace TinyProjectDataAccess
{
    /// <summary>
    /// AppDbContext
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// AppDbContext
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
