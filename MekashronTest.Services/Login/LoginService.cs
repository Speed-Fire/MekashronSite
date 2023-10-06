using MekashronTest.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekashronTest.Services.Login
{
    public class LoginService : ILoginService
    {
        public async Task<IBaseResponse<bool>> Login(string username, string password, string ip)
        {
            var client = new AuthenticationService.ICUTechClient();

            await client.OpenAsync();

            var response = await client.LoginAsync(username, password, ip);

            await client.CloseAsync();

            throw new NotImplementedException();
        }
    }
}
