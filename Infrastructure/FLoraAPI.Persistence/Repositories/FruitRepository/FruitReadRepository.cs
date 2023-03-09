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
    public class FruitReadRepository : ReadRepository<Fruit>, IFruitReadRepository
    {
        public FruitReadRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
