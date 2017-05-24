using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WebQLThuVien.Models
{
    public class Book
    {
        public Book()
        {
            Tickets = new List<Ticket>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nhà xuất bản")]
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        [Required]
        [Display(Name = "Danh mục thể loại")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Required]
        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        [Required]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }
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
        [Display(Name = "Ảnh bìa")]
        public string ThumbnailUrl { get; set; }

        [NotMapped]
        [Display(Name = "Số lượng còn lại")]
        public int CountLeft => Count - Tickets.Count(x => x.DateReturned == null);

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}