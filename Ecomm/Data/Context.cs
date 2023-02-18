using Ecomm.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }        
        public DbSet<Book> Books { get; set; }        
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<BookWritter> BookWritters { get; set; }        
    }
}
