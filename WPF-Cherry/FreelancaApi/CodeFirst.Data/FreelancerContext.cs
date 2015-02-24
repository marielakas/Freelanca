using System;
using System.Data.Entity;
using System.Linq;
using CodeFirst.Model;

namespace CodeFirst.Data
{
    public class FreelancerContext : DbContext
    {
        public FreelancerContext()
            : base("FreelancerDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Category> Categories { get; set; }

        //public DbSet<Difficulty> Difficulty { get; set; }

        //public DbSet<Category> Category { get; set; }
    }
}
