﻿using System.Data.Entity;

namespace OLMS.BackEnd.Model
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultBusinessConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public static BusinessDbContext Create()
        {
            return new BusinessDbContext();
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentContent> StudentContents { get; set; }
    }
}
