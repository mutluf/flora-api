using AutoMapper;
using FloraAPI.Application.Repositories;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.TreeFeatures.Queries
{
    public class GetTreeByIdRequest : IRequest<GetTreeByIdResponse>
    {
        public string Id { get; set; }
    }

    public class GetTreeByIdHandler : IRequestHandler<GetTreeByIdRequest, GetTreeByIdResponse>
    {
        ITreeReadRepository _treeReadRepository;

        public GetTreeByIdHandler(ITreeReadRepository treeWriteReadRepository)
        {
            _treeReadRepository = treeWriteReadRepository;
        }

        public async Task<GetTreeByIdResponse> Handle(GetTreeByIdRequest request, CancellationToken cancellationToken)
        {
            Tree tree = await _treeReadRepository.GetByIdAysnc(request.Id);

            return new()
            {
                Tree = tree,
            };
        }
    }
    //ya balım kusura bakma böyle olunca da mahcup oluyorum buna da çağırma deme sen bana :")) yok balım ne güzel işte hemen çözülüyor bazen olmaz öyle şey.

    public class GetTreeByIdResponse
    {
        public Tree Tree { get; set; }
    }
}
