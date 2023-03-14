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
    public class GetFarmerByIdRequest : IRequest<GetFarmerByIdResponse>
    {
        public string Id { get; set; }
    }

    public class GetFarmerByIdHandler : IRequestHandler<GetFarmerByIdRequest, GetFarmerByIdResponse>
    {
        IFarmerReadRepository _farmerReadRepository;

        public GetFarmerByIdHandler(IFarmerReadRepository farmerReadRepository)
        {
            _farmerReadRepository = farmerReadRepository;
        }

        public async Task<GetFarmerByIdResponse> Handle(GetFarmerByIdRequest request, CancellationToken cancellationToken)
        {
            Farmer farmer = await _farmerReadRepository.GetByIdAysnc(request.Id);
            return new()
            {
                Farmer = farmer,
            };
        }
    }

    public class GetFarmerByIdResponse
    {
        public Farmer Farmer { get; set; }
    }
}
