using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebQLThuVien.Models
{
    public class Ticket
    {
        public Ticket()
        {
            Books = new List<Book>();
        }

        [Display(Name = "Mã phiếu")]
        [DisplayFormat(DataFormatString = "PM{0:0000}")]
        public int Id { get; set; }
        [Display(Name = "Người mượn")]
        public int ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        public virtual Reader Reader { get; set; }
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Ngày trả")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Chưa trả")]
        public DateTime? DateReturned { get; set; }
        [Display(Name = "Sách mượn")]
        public virtual ICollection<Book> Books { get; set; }

        [NotMapped]
        [Display(Name = "Tình trạng")]
        public string Status => DateReturned.HasValue ? "Đã trả" : "Chưa trả";

        [NotMapped]
        public string MaPhieu => "PM" + Id.ToString("000000");
    }
}