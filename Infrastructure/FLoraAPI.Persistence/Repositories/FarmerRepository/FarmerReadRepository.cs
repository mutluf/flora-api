using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Domain.Entities;
using FLoraAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLoraAPI.Persistence.Repositories.FarmerRepository
{
    public class FarmerReadRepository : ReadRepository<Farmer>, IFarmerReadRepository
    {
        public FarmerReadRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
