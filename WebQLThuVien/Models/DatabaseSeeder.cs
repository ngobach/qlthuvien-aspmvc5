using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Faker;
using Faker.Extensions;

namespace WebQLThuVien.Models
{
    internal class MySeeder
    {
        private static readonly string[] BookTitles =
        {
            "Lạc Vào Miền Cổ Tích 02 - Phù Thủy Hắc Ám Trở Lại",
            "Nguyễn Nhật Ánh Trong Mắt Đồng Nghiệp",
            "Combo Gấu Xù Kể Chuyện (Bộ 3 Cuốn)",
            "Gấu Xù Kể Chuyện - Ba Anh Em",
            "Gấu Xù Kể Chuyện - Chiếc Áo Tàng Hình",
            "Gấu Xù Kể Chuyện - Ngỗng Già Thông Minh",
            "Thực Khách Hay Thực Đơn",
            "Khát Vong Việt Vì Sao Đất Nước Ta Còn Nghèo",
            "Quà Tặng Thiệp Màu Cuốn Em Giày Xanh, Anh Giày Đỏ - Tặng Kèm Thiệp Màu (Số Lượng Có Hạn)",
            "Em Giày Xanh, Anh Giày Đỏ ",
            "101 Cách Chữa Lành Vết Thương Cho Con Sau Đổ Vỡ - Để Con Không Tổn Thương Và Vẫn Luôn Yêu Bố Mẹ ",
            "Tư Duy Logic",
            "Làm Dâu Nhà Má ",
            "Đừng Từ Bỏ",
            "Từ Điển Việt Hán (10 x 16)",
            "All You Need Is Kill - Cuộc Chiến Luân Hồi (Light Novel) - Tặng Kèm 01 Postcard (Số Lượng Có Hạn)",
            "All You Need Is Kill - Cuộc Chiến Luân Hồi (Manga Bộ 2 Tập) - Tặng Kèm 02 Postcard Giấy (Số Lượng Có Hạn)",
            "All You Need Is Kill - Cuộc Chiến Luân Hồi (Bộ Hộp) - Bản Đặc Biệt - Tặng Kèm Clearfile Và Postcard Chất Liệu Nhựa Đặc Biệt (Số Lượng Có Hạn)",
            "Ác Mộng Trong Đêm ",
            "108 Chuyện Kể Hay Nhất Về Các Loài Cây Và Hoa Quả - Tập 2",
            "Ngôi Nhà Của Người Cá Say Ngủ ",
            "Thống Kê Trong Kinh Tế Và Kinh Doanh",
            "Nuôi Dưỡng Tâm Hồn - Hộp 6 Cuốn",
            "Bài Học Từ Người Quét Rác - Danh Nhân Với Tinh Thần Xã Hội",
            "Thái Độ Sống Tạo Nên Tất Cả! (Tái Bản 2016)",
            "Vùng Cách Ly ",
            "Combo Bộ Sách Sự Kỳ Diệu Của Cơ Thể (Bộ 4 Cuốn)",
            "Sự Kỳ Diệu Của Cơ Thể - ​Bí Mật Của Chiều Cao",
            "Combo Song Ngữ The Diary Of A Young Girl - Nhật Ký Anne Frank (Tái Bản)",
            "Sự Kỳ Diệu Của Cơ Thể - ​​​Bí Mật Của Chuyện Đi Ị",
            "Sự Kỳ Diệu Của Cơ Thể - ​​Bí Mật Của Thân Nhiệt",
            "3500 Từ Vựng Tiếng Anh Thông Dụng",
            "Sự Kỳ Diệu Của Cơ Thể  - Bí Mật Của Trái Tim",
            "Bộ Điều Tuyệt Vời Nhất Của Thanh Xuân (2 Tập) - Tặng Kèm 1 Poster Và 4 Postcard (Số Lượng Có Hạn)",
            "Combo Happy Reader - Khu Vườn Bí Mật (Sách Kèm CD)",
            "Bách Khoa Tri Thức Về Khám Phá Thế Giới Cho Trẻ Em - Thiên Văn Học (Tái Bản 2017)",
            "Bách Khoa Tri Thức Về Khám Phá Thế Giới Cho Trẻ Em - Khủng Long (Tái Bản 2017)",
            "Bách Khoa Tri Thức Về Khám Phá Thế Giới Cho Trẻ Em - Các Loài Rắn (Tái Bản 2017)",
            "Chạm Một Miền Xuân",
            "Kinh Dịch Dự Đoán (Bìa Cứng)",
            "Em Học Giỏi Tiếng Anh Lớp 7 - Tập 1 (Bìa Mềm)",
            "Em Học Giỏi Tiếng Anh Lớp 7 - Tập 2 (Bìa Mềm)",
            "Bách Khoa Tri Thức Động Vật Cho Bé Song Ngữ Anh Việt ( 10 Cuốn)",
            "Từ Điển Anh Việt - Việt Anh (Bìa Cứng)",
            "Tập Viết Tiếng Nhật Căn Bản Kanji",
            "Lượng Từ Tiếng Hán Hiện Đại (Sách Màu)",
            "Đàm Đạo Với Khổng Tử",
            "Em Yêu Toán Học - Tập 1",
            "Em Yêu Toán Học - Tập 2",
            "Em Yêu Toán Học - Tập 3",
            "Em Yêu Toán Học - Tập 4",
            "Em Yêu Toán Học - Tập 5",
            "Truyện Cổ Việt Nam Đặc Sắc - Cậu Bé Tích Chu",
            "Đàm Đạo Với Lão Tử",
            "Truyện Cổ Việt Nam Đặc Sắc - Cây Khế",
            "Truyện Cổ Việt Nam Đặc Sắc - Cây Tre Trăm Đốt",
            "Truyện Cổ Việt Nam Đặc Sắc - Chú Cuội",
            "Truyện Cổ Việt Nam Đặc Sắc - Sơn Tinh Thuỷ Tinh",
            "Truyện Cổ Việt Nam Đặc Sắc - Sự Tích Dưa Hấu",
            "Truyện Cổ Việt Nam Đặc Sắc - Thạch Sanh",
            "Truyện Cổ Việt Nam Đặc Sắc - Tấm Cám",
            "Hẹn gặp em",
            "Tục Ngữ Phong Dao - Một Kho Vàng Chung Của Nhân Loại (Bìa Cứng)",
            "Combo Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi (Bộ 8 Cuốn)",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Activity Book 4",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Activity Book 3",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Activity Book 2",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Activity Book 1",
            "Bồi Dưỡng Học Sinh Vào Lớp 6 Môn Tiếng Anh",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Reder Book 4",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Reder Book 3",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Reder Book 2",
            "Hooray English - Tiếng Anh Vừa Học Vừa Chơi Dành Cho Bé Từ 4-6 Tuổi - Reder Book 1",
            "50 Ghi Chép Ngắn Từ Lịch Sử Lâu Dài Của Hạnh Phúc",
            "Carol - Patricia Highsmith",
            "Đại Việt Sử Ký Toàn Thư (Tái Bản 2017)",
            "Câu Chuyện Quản Lý Cà Rốt Và Nghệ Thuật Khen Thưởng (Tái Bản 2017)",
            "Những Bài Làm Văn Tiêu Biểu 10",
            "Hachiko - Chú Chó Đợi Chờ (Bìa Mềm)",
            "Ghi Và Nhớ",
            "Cô Gái Hà Nội Mập Mặc Burqa",
            "Bí Ẩn Mãi Mãi Là Bí Ẩn - Tập 6 (Tái Bản 2017)",
            "Cẩm Nang Tự Học Ielts",
            "Vietmath Cùng Con Giỏi Tư Duy Toán Học - Tập 5",
            "Vị Thế Việt Nam (Viet Nam’S Status In The World)",
            "Nhớ Sao Xe Cộ Sài Gòn",
            "Luật Viên Chức (2015)",
            "Chicken Soup For The Soul - Dành Cho Những Tâm Hồn Bất Hạnh (Tái Bản 2017)",
            "Tân Tiểu Đầu Bếp Cung Đình (Tập 5)",
            "Hikaru - Kì Thủ Cờ Vây (Tập 22)",
            "Yu-Gi-Oh! - Vua Trò Chơi (Tập 15)",
            "Con Người Với Tâm Linh",
            "Magi - Mê Cung Thần Thoại (Tập 29)",
            "Bài Tập Tiếng Anh 12 (Có Đáp Án) - 2017",
            "Bài Tập Tiếng Anh 12 (Không Đáp Án) - 2017",
            "Bài Tập Tiếng Anh 11 (Có Đáp Án) - 2017",
            "Bài Tập Tiếng Anh 10 (Có Đáp Án) - 2017",
            "Bài Tập Tiếng Anh 11 (Không Đáp Án) - 2017",
            "Bài Tập Tiếng Anh 10 (Không Đáp Án) - 2017",
            "Cùng Chơi Với Bé - Mặc Quần Áo Thật Dễ",
            "Cùng Chơi Với Bé - Cù Lét! Cù Lét!",
            "Cùng Chơi Với Bé - Cái Ôm Ấm Áp",
            "Cùng Chơi Với Bé - Tạm Biệt! Tạm Biệt!",
            "Cùng Chơi Với Bé - Câu Trả Lời Dễ Thương",
            "Cùng Chơi Với Bé - Tự Đi Vệ Sinh",
            "Cùng Chơi Với Bé - Chúc Bạn Ngon Miệng",
            "Yona - Công Chúa Bình Minh - Tập 1",
            "Shaman King (Tập 6)",
            "Cẩm Nang Kinh Doanh - Quản Lý Khủng Hoảng (Tái Bản 2017)",
            "Bí Mật Quyến Rũ",
            "3 Đêm Trước Giao Thừa",
            "Trái Tim Trên Những Con Đường",
            "Chiếc Ô Chia Mưa",
            "Cô Mèo Đen Quý Tộc",
            "100 Viên Gạch Xây Dựng Kỹ Năng Lãnh Đạo",
            "Phương Pháp Học Tập Hiệu Quả",
            "Trò Chuyện Với Cõi Vô Hình",
            "Biên Nhược Thủy (Tập 3+4) - Tặng Kèm 2 Bookmark Và 1 Poscard 2 Mặt (Số Lượng Có Hạn)",
            "5 Ngôn Ngữ Tình Yêu - Dành Cho Trẻ Em (Tái Bản 2017)",
            "Sách Giáo Khoa Bộ Lớp 12 Ban Chuẩn (Bài Học - 14 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 11 Ban Chuẩn (Bài Học - 14 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 10 Ban Chuẩn (Bài Học - 14 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 9 (Bài Tập - 7 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 9 (Bài Học - 12 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 8 (Bài Tập - 7 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 8 (Bài Học - 13 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 7 (Bài Tập - 6 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 7 (Bài Học - 12 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 6 (Bài Học Và Bài Tập - 18 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 6 (Bài Tập - 6 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 6 (Bài Học - 12 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 5 (Bài Học Và Bài Tập - 20 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 5 (Bài Tập - 12 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 5 (Bài Học - 9 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 4 (Bài Học Và Bài Tập - 20 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 4 (Bài Tập 11 Cuốn)",
            "Bộ Sách Giáo Khoa Bộ Lớp 4 (Bài Học 9 Cuốn)",
            "Tảng Băng Tan - Đổi Mới Và Thành Công Trong Mọi Hoàn Cảnh (Tái Bản 2017)",
            "Toán So Sánh",
            "Giải Bài Tập Tiếng Anh Lớp 8 - Tập 2",
            "Elon Musk - Muốn Thay Đổi Thế Giới",
            "Pháo Đài Số ",
            "Combo Chiến Lược Luyện Thi THPT 2 (Bộ 4 Cuốn)",
            "Combo Chiến Lược Luyện Thi THPT 1 (Bộ 4 Cuốn)",
            "Combo Môn Ngữ Văn THPT (Bộ 2 Cuốn)",
            "Combo Môn Toán THPT (Bộ 3 Cuốn)",
            "Combo Môn Toán - Văn - Anh THPT (Bộ 3 Cuốn)",
            "7 Thói Quen Của Bạn Trẻ Thành Đạt (Tái bản 2017)",
            "Sách Giáo Khoa Bộ Lớp 3 (Bài Học và Bài Tập - 13 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 2 (Bài Học và Bài Tập - 13 Cuốn)",
            "Sách Giáo Khoa Bộ Lớp 1 (Bài Học Và Bài Tập - 13 Cuốn)",
            "Bồi Dưỡng Năng Lực Tự Học Vật Lý 8",
            "Bồi Dưỡng Năng Lực Tự Học Hóa Học Lớp 8",
            "Combo Những Những Câu Chuyện Về (Bộ 4 Cuốn)",
            "Những Câu Chuyện Về Lòng Dũng Cảm",
            "Những Câu Chuyện Về Lòng Thương Người",
            "Những Câu Chuyện Về Tình Bạn",
            "Những Câu Chuyện Về Tính Lương Thiện",
            "Trump - Đừng Bao Giờ Bỏ Cuộc",
            "Yu Yu Và Các Bạn - Mẹ Ơi Con Có Ngoan Không",
            "Yu Yu Và Các Bạn - Trên Xe Buýt",
            "One Punch Man - Tập 3",
            "Mật Mã Đặc Khu",
            "Bản Kế Hoạch Thay Đổi Định Mệnh",
            "Bài Tập Bổ Trợ Kiến Thức Tiếng Anh Lớp 5 Tập 2",
            "Bài Tập Trắc Nghiệm Tiếng Anh Lớp 10 - Tập 2 ",
            "99 Việc Cần Làm Trước Khi Tốt Nghiệp Đại Học",
            "Combo Chú Chó Shiloh (Bộ 3 Cuốn)",
            "Thời Đại Gái Ế (Tái Bản Lần Thứ 1 - 2017)",
            "Conan Tay Bắn Tỉa Ở Chiều Không Gian Khác (Hoạt Hình Màu) - Tập 1",
            "Đời Chẳng Có Ai Là Hoàn Hảo",
            "Tự Cứu Mình (Quyển 2)",
            "Hướng Dẫn Khởi Nghiệp Với Nghề Luật Sư (Tái Bản 2017)",
            "Chuyện Trời Ơi Đất Hỡi",
            "Bài Tập Tiếng Anh Lớp 8 - Có Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 9 - Không Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Thực Hành Tiếng Anh Lớp 6 - Có Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 9 - Có Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Thực Hành Tiếng Anh Lớp 6 - Không Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 8 - Không Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 7 - Có Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 7 - Không Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 6 - Không Đáp Án (2017 - Mai Lan Hương)",
            "Bài Tập Tiếng Anh Lớp 6 - Có Đáp Án (2017 - Mai Lan Hương)",
            "Lửa Hận",
            "Những Bài Văn Mẫu Lớp 4",
            "Ánh Trăng (Tái Bản 2017)",
            "Tìm Hiểu Văn Hóa Thời Đại Hùng Vương",
            "Hỏi Đáp Về 82 Bia Tiến Sĩ Tại Văn Miếu-Quốc Tử Giám",
            "Gương Sáng Trời Nam",
            "Những Bảng Nhãn Trong Lịch Sử Việt Nam",
            "Nâng Cao Đạo Đức Cách Mạng, Quét Sạch Chủ Nghĩa Cá Nhân (Khổ Nhỏ)"
        };

        private static readonly string[] Thumbnails =
        {
            "https://www.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/8/9/8932000125501_2.jpg",
            "https://www.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/m/image_121636.jpg",
            "https://www.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/8/9/8935235207189.jpg",
            "https://www.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/9/7/9780735212169_1.png",
            "https://www.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/d/i/dieu-bi-mat-1_1.jpg"
        };

        public static void Seed(ThuVienDb context)
        {
            // Users
            context.Users.Add(new User
            {
                Username = "bachnx",
                Password = "matkhau",
                Email = "mail@ngobach.com",
                Fullname = "Ngô Xuân Bách"
            });
            context.Users.Add(new User
            {
                Username = "namdv",
                Password = "matkhau",
                Email = "dinhnamitvn@gmail.com",
                Fullname = "Đinh Viết Nam"
            });
            // Authors
            context.Authors.AddRange(new[]
            {
                new Author {Name = "Nguyễn Ngọc Ngạn", Description = "Giới thiệu tác giả"},
                new Author {Name = "Trần Thu Hương", Description = "Giới thiệu tác giả"},
                new Author {Name = "Bùi Quốc Dũng", Description = "Giới thiệu tác giả"},
                new Author {Name = "Hoàng Văn Quân", Description = "Giới thiệu tác giả"},
                new Author {Name = "Đinh Sơn Nam", Description = "Giới thiệu tác giả"},
                new Author {Name = "Ngô Ngọc Thành", Description = "Giới thiệu tác giả"},
                new Author {Name = "Bùi Xuân Quyết", Description = "Giới thiệu tác giả"}
            });
            // Publisher
            context.Publishers.AddRange(new[]
            {
                new Publisher {Name = "Kim Đồng", Description = "Giới thiệu về nhà xuất bản"},
                new Publisher {Name = "Tuổi trẻ", Description = "Giới thiệu về nhà xuất bản"},
                new Publisher {Name = "Văn Học", Description = "Giới thiệu về nhà xuất bản"},
                new Publisher {Name = "Điện Lực", Description = "Giới thiệu về nhà xuất bản"}
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
                new Category {Name = "Sách nông nghiệp"}
            });
            // Reader
            var readers = new List<Reader>();
            readers.Add(new Reader
            {
                Username = "bachnx",
                Password = "matkhau",
                Fullname = "Ngô Xuân Bách",
                Address = Address.StreetAddress(),
                PhoneNumber = "0987654321",
                Email = "mail@example.com"
            });
            for (var i = 0; i < 50; i++)
                readers.Add(new Reader
                {
                    Username = Internet.UserName(),
                    Password = "123456",
                    Fullname = Name.FullName(),
                    Address = Address.StreetAddress(),
                    PhoneNumber = "0987654321",
                    Email = "mail@example.com"
                });
            context.Readers.AddRange(readers);
            context.SaveChanges();
            // Books
            var authors = context.Authors.ToList();
            var publishers = context.Publishers.ToList();
            var categories = context.Categories.ToList();
            var books = BookTitles //Enumerable.Range(0, 200)
                .Select(x => new Book
                {
                    Author = authors[RandomNumber.Next(authors.Count)],
                    Category = categories[RandomNumber.Next(categories.Count)],
                    Publisher = publishers[RandomNumber.Next(publishers.Count)],
                    Count = RandomNumber.Next(10, 100),
                    Description = Lorem.Paragraph(),
                    Name = x,
                    Price = RandomNumber.Next(10, 100) * 1000,
                    NumberOfPage = RandomNumber.Next(40, 345),
                    PublishYear = RandomNumber.Next(2008, 2017),
                    ThumbnailUrl = Thumbnails.Random()
                })
                .ToList();
            context.Books.AddRange(books);
            // Tickets
            var tickets = new List<Ticket>();
            for (var i = 0; i < 30; i++)
            {
                var date = DateTime.Today.Subtract(new TimeSpan(i, 0, 0, 0));
                for (var j = 0; j < RandomNumber.Next(5, 15); j++)
                {
                    var ticket = new Ticket { DateCreated = date, Reader = readers[RandomNumber.Next(readers.Count)] };
                    var tmp = RandomNumber.Next(4) + 2;
                    if (i >= tmp)
                        ticket.DateReturned = date.Add(new TimeSpan(tmp, 0, 0, 0));
                    tmp = RandomNumber.Next(3, 6);
                    while (tmp-- >= 0)
                        ticket.Books.Add(books[RandomNumber.Next(books.Count)]);
                    tickets.Add(ticket);
                }
            }
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }

    public class DebugDatabaseSeeder : DropCreateDatabaseAlways<ThuVienDb>
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