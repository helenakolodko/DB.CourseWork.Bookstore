using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.CourseWork.Bookstore.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Count { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public DateTime Added { get; set; }
    }
}