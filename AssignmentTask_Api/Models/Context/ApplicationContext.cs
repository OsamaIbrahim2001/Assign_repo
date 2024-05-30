using Microsoft.EntityFrameworkCore;

namespace AssignmentTask_Api.Models.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(x => x.Rooms).WithOne(x => x.Book).HasForeignKey(x => x.BookId
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBookProperty> CustomerBookProperties { get; set; }

    }
}
