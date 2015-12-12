using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.CourseWork.Bookstore.Models
{
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Username{ get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
       // public virtual UserInfo UserInfo { get; set; }
    }
}