using AutoMapper;
using FloraAPI.Application.Features.FarmerFeatures.Commands;
using FloraAPI.Application.Features.TreeFeatures.Commands;
using FloraAPI.Application.Features.UsersFeatures.Commands;
using FloraAPI.Domain.Entities;
using FloraAPI.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateTreeRequest, Tree>().ReverseMap();
            CreateMap<UpdateTreeRequest, Tree>().ReverseMap();
            CreateMap<CreateFarmerRequest,Farmer>().ReverseMap();
            CreateMap<CreateUserRequest,User>().ReverseMap();
           

        }
    }
}
