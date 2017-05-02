using System.Data.Entity;

namespace WebQLThuVien.Models
{
    public class DatabaseSeeder : DropCreateDatabaseIfModelChanges<ThuVienDb>
    {
        protected override void Seed(ThuVienDb context)
        {
            // Users
            context.Users.Add(new User { Username = "bachnx", Password = "matkhau", Email = "mail@ngobach.com", Fullname = "Ngô Xuân Bách"});
            context.Users.Add(new User { Username = "namdv", Password = "matkhau", Email = "dinhnamitvn@gmail.com", Fullname = "Đinh Viết Nam"});
            // Authors
            context.Authors.AddRange(new[]
            {
                new Author { Name = "Nguyễn Ngọc Ngạn", Description = "Nothing" },
                new Author { Name = "Trần Thu Hương", Description = "Nothing" },
                new Author { Name = "Bùi Quốc Dũng", Description = "Nothing" },
                new Author { Name = "Hoàng Văn Quân", Description = "Nothing" },
                new Author { Name = "Đinh Sơn Nam", Description = "Nothing" },
                new Author { Name = "Ngô Ngọc Thành", Description = "Nothing" },
                new Author { Name = "Bùi Xuân Quyết", Description = "Nothing" },
            });
            // Publisher
            context.Publishers.AddRange(new[]
            {
                new Publisher { Name = "Kim Đồng", Description = "Nothing"},
                new Publisher { Name = "Tuổi trẻ", Description = "Nothing"},
                new Publisher { Name = "Văn Học", Description = "Nothing"},
                new Publisher { Name = "Điện Lực", Description = "Nothing"},
            });
            // Category
            context.Categories.AddRange(new[]
            {
                new Category {Name = "Tiểu thuyết"},
                new Category {Name = "Sách giáo khoa"},
                new Category {Name = "Truyện tiếu lâm"},
                new Category {Name = "Truyện thiếu nhi"},
                new Category {Name = "Sách văn học"},
                new Category {Name = "Sách tham khảo"},
                new Category {Name = "Khoa học viễn tưởng"},
                new Category {Name = "Truyện tranh"},
                new Category {Name = "Sách nông nghiệp"},
            });
            // Reader
            context.Readers.AddRange(new[]
            {
                new Reader { Fullname = "Ngô Xuân Bách", Address = "D8CNPM", PhoneNumber = "01693724182" },
                new Reader { Fullname = "Trần Anh Đức", Address = "D8CNPM", PhoneNumber = "01693724182" },
                new Reader { Fullname = "Trương Việt Anh", Address = "D8CNPM", PhoneNumber = "01693724182" },
                new Reader { Fullname = "Hoàng Văn Uông", Address = "D8CNPM", PhoneNumber = "01693724182" },
                new Reader { Fullname = "Lê Trung Híu", Address = "D8CNPM", PhoneNumber = "01693724182" },
            });
            context.SaveChanges();
            // Books
            // TODO: 
            // Tickets
            // TODO: 
            base.Seed(context);
        }
    }
}