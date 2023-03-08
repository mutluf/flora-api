using AutoMapper;
using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.FarmerFeatures.Commands.CreateFarmer
{
    public class CreateFarmerRequest:IRequest<CreateFarmerResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class CreateFarmerHandler : IRequestHandler<CreateFarmerRequest, CreateFarmerResponse>
    {
        IFarmerWriteRepository _farmerWriteRepository;
        IMapper _mapper;

        public CreateFarmerHandler(IFarmerWriteRepository farmerWriteRepository, IMapper mapper)
        {
            _farmerWriteRepository = farmerWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateFarmerResponse> Handle(CreateFarmerRequest request, CancellationToken cancellationToken)
        {
            Farmer farmer = _mapper.Map<Farmer>(request);
            await _farmerWriteRepository.AddAysnc(farmer);
            await _farmerWriteRepository.SaveAysnc();

            return new()
            {
                Message = "eklendi"
            };

        }
    }

    public class CreateFarmerResponse
    {
        public string Message { get; set; }
    }

}
