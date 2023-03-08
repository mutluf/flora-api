using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities;
using FLoraAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Repositories.TreeRepository
{
    public class TreeReadRepository : ReadRepository<Tree>, ITreeReadRepository
    {
        public TreeReadRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
