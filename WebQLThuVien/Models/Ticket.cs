using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLThuVien.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual Reader Reader { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}