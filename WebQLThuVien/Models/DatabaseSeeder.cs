using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Faker;

namespace WebQLThuVien.Models
{
    internal class MySeeder
    {
        public static void Seed(ThuVienDb context)
        {
            // Users
            context.Users.Add(new User { Username = "bachnx", Password = "matkhau", Email = "mail@ngobach.com", Fullname = "Ngô Xuân Bách" });
            context.Users.Add(new User { Username = "namdv", Password = "matkhau", Email = "dinhnamitvn@gmail.com", Fullname = "Đinh Viết Nam" });
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
            {
                var authors = context.Authors.ToList();
                var publishers = context.Publishers.ToList();
                var categories = context.Categories.ToList();
                var items = Enumerable.Repeat(0, 200)
                    .Select(x => new Book
                    {
                        Author = authors[RandomNumber.Next(authors.Count)],
                        Category = categories[RandomNumber.Next(categories.Count)],
                        Publisher =  publishers[RandomNumber.Next(publishers.Count)],
                        Count = RandomNumber.Next(10, 100),
                        Description = Lorem.Paragraph(),
                        Name = Lorem.Sentence(4),
                        Price = RandomNumber.Next(10, 100) * 1000,
                        NumberOfPage = RandomNumber.Next(40, 345),
                        PublishYear = RandomNumber.Next(2008, 2017)
                    });
                context.Books.AddRange(items);
            }
            // Tickets
            // TODO: 
        }
    }

    public class DebugDatabaseSeeder : DropCreateDatabaseIfModelChanges<ThuVienDb>
    {
        protected override void Seed(ThuVienDb context)
        {
            MySeeder.Seed(context);
            base.Seed(context);
        }
    }

    public class DatabaseSeeder : CreateDatabaseIfNotExists<ThuVienDb>
    {
        protected override void Seed(ThuVienDb context)
        {
            MySeeder.Seed(context);
            base.Seed(context);
        }
    }
}