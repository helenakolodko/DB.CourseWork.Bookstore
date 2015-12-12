using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DB.CourseWork.Bookstore.Models
{
    public class ShopContext: DbContext
    {
        public ShopContext()
            : base("name=ShopConnection")
        {
                    
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .Map(m => m.ToTable("UsersToRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}