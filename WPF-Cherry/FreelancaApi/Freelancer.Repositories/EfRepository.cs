﻿using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Freelancer.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required"+
                    "to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public T Add(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }
            this.Context.SaveChanges();

            return item;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Update(int id, T item)
        {
            //DbEntityEntry entry = this.Context.Entry(item);
            //if (entry.State == EntityState.Detached)
            //{
            //    this.DbSet.Attach(item);
            //}

            //entry.State = EntityState.Modified;
            var entityToUpdate = this.DbSet.Find(id);
            this.Context.Entry<T>(entityToUpdate).CurrentValues.SetValues(item);

            this.Context.SaveChanges();
        }
    }
}
