using FloraAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateToken(int minute);
    }
}
