using AutoMapper;
using FloraAPI.Application.Abstractions.Cache;
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
        ICacheService _cacheService;

        public GetTreeHandler(ITreeReadRepository treeReadRepository, ICacheService cacheService)
        {
            _treeReadRepository = treeReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetTreeResponse> Handle(GetTreeRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Tree> trees = await _cacheService.GetOrAddAsync("trees", async () =>
            {
                trees = _treeReadRepository.GetAll();
                return trees;
            });
            

            return new()
            {
                Trees = trees
            };
        }
    }

    public class GetTreeResponse
    {
        public IQueryable<Tree>? Trees { get; set; }
    }
}
