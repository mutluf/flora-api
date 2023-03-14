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
    public class CreateTreeRequest : IRequest<CreateTreeResponse>
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int FarmerId { get; set; }
    }

    public class CreateTreeHandler : IRequestHandler<CreateTreeRequest, CreateTreeResponse>
    {
        private readonly ITreeWriteRepository _treeWriteRepository;
        IMapper _mapper;

        public CreateTreeHandler(ITreeWriteRepository treeWriteRepository, IMapper mapper)
        {
            _treeWriteRepository = treeWriteRepository;
            _mapper = mapper;
        }


        public async Task<CreateTreeResponse> Handle(CreateTreeRequest request, CancellationToken cancellationToken)
        {
            Tree tree = _mapper.Map<Tree>(request);
            await _treeWriteRepository.AddAysnc(tree);
            await _treeWriteRepository.SaveAysnc();
            return new()
            {
                Message = "başarılı"
            };
        }
    }

    public class CreateTreeResponse
    {
        public string Message { get; set; }

    }
}
