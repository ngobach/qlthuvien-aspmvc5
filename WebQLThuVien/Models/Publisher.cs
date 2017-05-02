﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLThuVien.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên nhà xb")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Giới thiệu về nxb")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}