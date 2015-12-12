using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.CourseWork.Bookstore.Models
{
    public partial class Author
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MidName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}