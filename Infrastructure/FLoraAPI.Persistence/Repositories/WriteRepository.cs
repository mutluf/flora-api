using FloraAPI.Application.Repositories;
using FloraAPI.Domain.Entities.Common;
using FLoraAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly FloraAPIDbContext _context;

        public WriteRepository(FloraAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<bool> AddAysnc(T Model)
        {
            EntityEntry entityEntry= await Table.AddAsync(Model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<int> SaveAysnc()
        {
           return await _context.SaveChangesAsync();
        }

        public bool Update(T Model)
        {
           EntityEntry entityEntry = _context.Update(Model);
            return entityEntry.State== EntityState.Modified;    
        }
    }
}
