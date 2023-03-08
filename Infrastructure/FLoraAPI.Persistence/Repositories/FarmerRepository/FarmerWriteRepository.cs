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
    public class FarmerWriteRepository : WriteRepository<Farmer>, IFarmerWriteRepository
    {
        public FarmerWriteRepository(FloraAPIDbContext context) : base(context)
        {
        }
    }
}
