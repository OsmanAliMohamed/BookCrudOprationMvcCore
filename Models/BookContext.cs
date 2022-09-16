using Microsoft.EntityFrameworkCore;

namespace BooksCrudOperation.Models
{
    public class BookContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=OSMAN;Initial Catalog=BookDb;Trusted_Connection=True;");
        }
    }
}
