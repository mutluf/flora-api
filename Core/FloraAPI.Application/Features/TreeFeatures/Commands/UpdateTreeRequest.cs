using AutoMapper;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.TreeFeatures.Commands
{
    public class UpdateTreeRequest : IRequest<UpdateTreeResponse>
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }
        public string? Type { get; set; }
    }

    public class UpdateTreeHandler : IRequestHandler<UpdateTreeRequest, UpdateTreeResponse>
    {
        ITreeWriteRepository _treeWriteRepository;
        IMapper _mapper;
        public UpdateTreeHandler(ITreeWriteRepository treeWriteRepository, IMapper mapper)
        {
            _treeWriteRepository = treeWriteRepository;
            _mapper = mapper;
        }


        public async Task<UpdateTreeResponse> Handle(UpdateTreeRequest request, CancellationToken cancellationToken)
        {
            Tree tree = _mapper.Map<Tree>(request);
            _treeWriteRepository.Update(tree);
            await _treeWriteRepository.SaveAysnc();

            return new()
            {
                Message = "güncellendi"
            };
        }
    }

    public class UpdateTreeResponse
    {
        public string Message { get; set; }

    }
}
