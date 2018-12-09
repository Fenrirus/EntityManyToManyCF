using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityManyToManyCF
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(t => t.Courses)
                .WithMany(s => s.Students)
                .Map(m => {
                    m.MapLeftKey("StudentID");
                    m.MapRightKey("CourseID");
                    m.ToTable("StudentCourses");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}