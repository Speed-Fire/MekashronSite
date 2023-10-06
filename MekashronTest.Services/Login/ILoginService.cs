using MekashronTest.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekashronTest.Services.Login
{
    public interface ILoginService
    {
        Task<IBaseResponse<bool>> Login(string username, string password, string ip);
    }
}
