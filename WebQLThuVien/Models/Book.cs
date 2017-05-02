using System.Collections.Generic;

namespace WebQLThuVien.Models
{
    public class Book
    {
        public int Id { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public int NumberOfPage { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}