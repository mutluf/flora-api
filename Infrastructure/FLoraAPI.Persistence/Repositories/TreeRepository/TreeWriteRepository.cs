using FloraAPI.Application.Repositories;
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
    public class TreeWriteRepository : WriteRepository<Tree>, ITreeWriteRepository
    {
        public TreeWriteRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
