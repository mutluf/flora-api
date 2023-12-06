using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Domain.Entities;
using MediatR;

namespace FloraAPI.Application.Features.FarmerFeatures.Commands
{
    public class DeleteFarmerRequest:IRequest<DeleteFarmerResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteFarmerHandler : IRequestHandler<DeleteFarmerRequest, DeleteFarmerResponse>
    {

        IFarmerWriteRepository _farmerWriteRespository;
        IFarmerReadRepository _farmerReadRepository;
        public DeleteFarmerHandler(IFarmerWriteRepository farmerWriteRespository, IFarmerReadRepository farmerReadRepository)
        {
            _farmerWriteRespository = farmerWriteRespository;
            _farmerReadRepository = farmerReadRepository;
        }

        public async Task<DeleteFarmerResponse> Handle(DeleteFarmerRequest request, CancellationToken cancellationToken)
        {
            Farmer farmer = await _farmerReadRepository.GetByIdAysnc(request.Id);
            _farmerWriteRespository.Delete(farmer);
            await _farmerWriteRespository.SaveAysnc();

            return new()
            {
                Message = "Başarıyla silindi"
            };
        }
    }

    public class DeleteFarmerResponse
    {
        public string Message { get; set; }
    }
}
