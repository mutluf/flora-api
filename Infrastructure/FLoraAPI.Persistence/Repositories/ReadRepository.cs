using FloraAPI.Application.Repositories;
using FloraAPI.Domain.Entities.Common;
using FLoraAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly FloraAPIDbContext _context;
        public ReadRepository( FloraAPIDbContext context)
        {
                _context= context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll()
        {
           var query = Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAysnc(string id)
        {
            var query = Table.AsQueryable();

            return await query.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
        }

        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> method)
        {
        
            var query = Table.AsQueryable();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query =  Table.Where(method).AsQueryable();
            return query;
        }
    }
}
