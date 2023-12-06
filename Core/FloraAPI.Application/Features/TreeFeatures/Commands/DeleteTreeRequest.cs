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
    public class DeleteTreeRequest:IRequest<DeleteTreeResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteTreeHandler : IRequestHandler<DeleteTreeRequest, DeleteTreeResponse>
    {
        ITreeReadRepository _treeReadRepository;
        ITreeWriteRepository _treeWriteRepository;
        public DeleteTreeHandler(ITreeReadRepository treeReadRepository, ITreeWriteRepository treeWriteRepository)
        {
            _treeReadRepository = treeReadRepository;
            _treeWriteRepository = treeWriteRepository;
        }

        public async Task<DeleteTreeResponse> Handle(DeleteTreeRequest request, CancellationToken cancellationToken)
        {
            Tree tree = await _treeReadRepository.GetByIdAysnc(request.Id);
            _treeWriteRepository.Delete(tree);
            await _treeWriteRepository.SaveAysnc();

            return new()
            {
                Message = "silindi"
            };
        }
    }

    public class DeleteTreeResponse
    {
        public string Message { get; set; }
    }
}
