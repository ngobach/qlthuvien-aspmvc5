using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQLThuVien.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        public string Fullname { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        [RegularExpression("^0[1-9][0-9]{8,9}$", ErrorMessage = "Số điện thoại không hợp lệ. VD: 01693724182")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Địa chỉ E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}