﻿using HamburgerApp.Core.DataAccess.Abstract;
using HamburgerApp.Core.Entities.Abstract;
using HamburgerApp.Core.Enums;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HamburgerApp.DataAccess.EntityFramework.Context;

namespace HamburgerApp.DataAccess.EntityFramework.Concrete
{
    public class BaseRepo<T> :IBaseRepo<T> where T : class,IBaseEntity
    {
        private readonly HamburgerAppDbContext _hamburgerAppDbContext;
        protected DbSet<T> _table;
        public BaseRepo(HamburgerAppDbContext hamburgerAppDbContext)
        {
            _hamburgerAppDbContext = hamburgerAppDbContext;
            _table = _hamburgerAppDbContext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }
        public async Task<bool> AddRange(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }
        public async Task<bool> Delete(T entity)
        {
            entity.Status = Status.Passive;
            entity.DeletedTime = DateTime.Now;
            return await Save() > 0;
        }
        public async Task<List<T>> GetAll() => await _table.Where(i => i.Status == Core.Enums.Status.Active).ToListAsync();
        public async Task<T> GetById(Guid id) => await _table.FindAsync(id);
        public async Task<int> Save()
        {
            return await _hamburgerAppDbContext.SaveChangesAsync();
        }
        public async Task<bool> Update(T entity)
        {
            _hamburgerAppDbContext.Entry<T>(entity).State = EntityState.Modified;
            return await Save() > 0;
        }
        public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }
        public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }
        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }
        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }

        }
    }
}
