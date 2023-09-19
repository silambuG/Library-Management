using Library_Management_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Application.Controllers
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<BookCategory> bookcategory { get; set; }
        public DbSet<Books> books { get; set; }
    }
}
