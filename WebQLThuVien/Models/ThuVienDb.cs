using System.Data.Entity;

namespace WebQLThuVien.Models
{
    public class ThuVienDb : DbContext
    {
        public ThuVienDb()
            : base("name=ThuVienDb")
        {
            Database.SetInitializer(new DatabaseSeeder());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}