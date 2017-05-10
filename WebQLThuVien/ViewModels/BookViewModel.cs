using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLThuVien.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Hình ảnh bìa")]
        public string ThumbnailUrl { get; set; }
        [Required]
        [Display(Name = "Giới thiệu về sách")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Năm xuất bản")]
        public int PublishYear { get; set; }
        [Required]
        [Display(Name = "Số trang")]
        public int NumberOfPage { get; set; }
        [Required]
        [Display(Name = "Số lượng")]
        public int Count { get; set; }
        [Range(0, 1000000000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }
        [Required]
        [Display(Name = "Danh mục thể loại")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Nhà xuất bản")]
        public int PublisherId { get; set; }
    }
}