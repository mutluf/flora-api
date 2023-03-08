using AutoMapper;
using FloraAPI.Application.Features.Commands.CreateTree;
using FloraAPI.Application.Features.Commands.UpdateTree;
using FloraAPI.Application.Features.FarmerFeatures.Commands.CreateFarmer;
using FloraAPI.Application.Features.UsersFeatures.Commands.CreateUser;
using FloraAPI.Application.Features.UsersFeatures.Commands.LoginUser;
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
            CreateMap<LoginUserRequest,User>().ReverseMap();    
           

        }
    }
}
