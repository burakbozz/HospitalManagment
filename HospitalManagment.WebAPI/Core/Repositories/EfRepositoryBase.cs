﻿using HospitalManagment.WebAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.WebAPI.Core.Repositories
{
    public class EfRepositoryBase<TContext,TEntity,TId> : IRepository<TEntity,TId>
        where TEntity : Entity<TId>, new()
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity? GetById(TId id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity? Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity? Add(TEntity entity)
        {
            
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public TEntity? Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
