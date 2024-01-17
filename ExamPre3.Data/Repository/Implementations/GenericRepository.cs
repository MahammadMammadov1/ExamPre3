using ExamPre3.Core.Repository.Interfaces;
using ExamPre3.Data.DAL;
using ExamPre3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Data.Repository.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _appDb;

        public GenericRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public Microsoft.EntityFrameworkCore.DbSet<TEntity> Table => _appDb.Set<TEntity>();

        public async Task<int> CommitAsync()
        {
            return await _appDb.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _appDb.AddAsync(entity);

        }

        public  void DeleteAsync(TEntity entity)
        {
             _appDb.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);
            return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);
            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetQuery(string[] includes)
        {
            var query = Table.AsQueryable();
            if (query is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }
}
