using System;
using CodeFirst.Data;
using CodeFirst.Model;
using Freelancer.Repositories;

namespace Freelancer.Services.Data
{
    public class UnitOfWork : IDisposable
    {
        private FreelancerContext context = new FreelancerContext();
        public IRepository<User> userRepository { get; private set; }
        public IRepository<Job> jobRepository { get; private set; }
        public IRepository<Tag> tagRepository { get; private set; }
        //public IRepository<Difficulty> difficultyRepository { get; private set; }
        public IRepository<Category> categoryRepository { get; private set; }
        private bool disposed = false;

        public UnitOfWork()
        {
            this.userRepository = new EfRepository<User>(this.context);
            this.jobRepository = new EfRepository<Job>(this.context);
            this.tagRepository = new EfRepository<Tag>(this.context);
            //this.difficultyRepository = new EfRepository<Difficulty>(this.context);
            this.categoryRepository = new EfRepository<Category>(this.context);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}