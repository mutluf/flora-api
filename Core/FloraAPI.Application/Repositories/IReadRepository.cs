﻿using FloraAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method);
        Task<T> GetByIdAysnc(string id);
        Task<T> GetSingleAysnc(Expression<Func<T,bool>> method);
    }
}
