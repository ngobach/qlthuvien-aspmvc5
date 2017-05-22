using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLThuVien.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}