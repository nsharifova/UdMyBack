using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class UdMyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server =.\;Database=UdMyDb;Trusted_Connection=true;MultipleActiveResultSets=True");
        }
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseSpecifaction> CourseSpecifactions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonVideo> LessonVideos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Specifaction> Specifactions { get; set; }

    }
}
