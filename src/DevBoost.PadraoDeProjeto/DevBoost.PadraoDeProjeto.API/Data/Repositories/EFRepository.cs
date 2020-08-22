using DevBoost.PadraoDeProjeto.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace DevBoost.PadraoDeProjeto.API.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
      

        private readonly DbContext _context;
        internal DbSet<T> _dbSet;
        //private DbSet<T> _entities;

      

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

       

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }


        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsQueryable().ToList();
        }
    }
}

