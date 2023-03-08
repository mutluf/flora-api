using FloraAPI.Application.Repositories.FruitRepository;
using FloraAPI.Domain.Entities;
using FLoraAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Repositories.FruitRepository
{
    public class FruitWriteRepository : WriteRepository<Fruit>, IFruitWriteRepository
    {
        public FruitWriteRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
