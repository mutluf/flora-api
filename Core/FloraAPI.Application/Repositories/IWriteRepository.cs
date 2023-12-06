using FloraAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T: BaseEntity
    {
        Task<bool> AddAysnc(T Model);
        bool Update(T Model);
        Task<int> SaveAysnc();
        void Delete(T Model);
    }
}
