using AutoMapper;
using FloraAPI.Application.Features.Commands.CreateTree;
using FloraAPI.Application.Features.Commands.UpdateTree;
using FloraAPI.Application.Features.FarmerFeatures.Commands.CreateFarmer;
using FloraAPI.Application.Features.UsersFeatures.Commands.CreateUser;
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
    {//mediatr sürüm hatasındanmış uyuşmazlık var 3 günde güncelleme gelmiş :)
        public GeneralMapping()
        {
            CreateMap<CreateTreeRequest, Tree>().ReverseMap();
            CreateMap<UpdateTreeRequest, Tree>().ReverseMap();//buraya bunu ekleyince güncelleme sorunu çözüldü
            CreateMap<CreateFarmerRequest,Farmer>().ReverseMap();// döne döne baktım valla bin kez baktım buraya ki balım şeyi bile öğrendim bak get işlemerinde map yapmadığımız için buraya uğramıyoruz önce get leri yaptım ama aklımda da hep burası var post olunca giderim diye yaaaaaa allah beni ne yapmasın anlaştıktamamdır kendime geçemiyorum.d evet
            CreateMap<CreateUserRequest,User>().ReverseMap();
           

        }
    }
}
