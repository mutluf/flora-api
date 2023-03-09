using AutoMapper;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.TreeFeatures.Queries.GetTree
{
    public class GetTreeRequest : IRequest<GetTreeResponse>
    {
        //burası boş haaa 
    }

    public class GetTreeHandler : IRequestHandler<GetTreeRequest, GetTreeResponse>
    {
        ITreeReadRepository _treeReadRepository;

        public GetTreeHandler(ITreeReadRepository treeReadRepository)
        {
            _treeReadRepository = treeReadRepository;
        }

        public async Task<GetTreeResponse> Handle(GetTreeRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Tree> trees = _treeReadRepository.GetAll();

            return new()
            {
                Trees = trees
            };
        }
    }

    public class GetTreeResponse
    {
        public IQueryable<Tree>? Trees { get; set; }//buralar doğru. kopya çektim canım doğru olsun <3 aslında buralar da değişir neden dersen buraya direkt entitiy vermek yerine field field yaparız ama şimdilik gerek yok.
    }
}
