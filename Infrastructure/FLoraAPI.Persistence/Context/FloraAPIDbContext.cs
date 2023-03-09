using FloraAPI.Domain.Entities;
using FloraAPI.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Context
{
    public class FloraAPIDbContext:IdentityDbContext<User,Role,int>
    {
        //bu constructor olmayınca no database provider has been configured for this DbContext hatası alındı.
        public FloraAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tree> Trees { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
    }// 
}
