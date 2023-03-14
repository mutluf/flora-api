using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.FarmerFeatures.Queries
{
    public class GetFarmerRequest : IRequest<GetFarmerResponse>
    {
    }

    public class GetFarmerHandler : IRequestHandler<GetFarmerRequest, GetFarmerResponse>
    {
        IFarmerReadRepository _farmerReadRepository;

        public GetFarmerHandler(IFarmerReadRepository farmerReadRepository)
        {
            _farmerReadRepository = farmerReadRepository;
        }

        public async Task<GetFarmerResponse> Handle(GetFarmerRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Farmer> farmers = _farmerReadRepository.GetAll();

            return new()
            {
                Farmers = farmers
            };
        }
    }

    public class GetFarmerResponse
    {
        public IQueryable<Farmer> Farmers { get; set; }
    }
}
