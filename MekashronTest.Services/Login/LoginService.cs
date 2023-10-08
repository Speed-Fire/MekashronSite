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
        public async Task<IBaseResponse<string>> Login(string username, string password, string ip)
        {
            var client = new AuthenticationService.ICUTechClient();

            await client.OpenAsync();

            var response = await client.LoginAsync(username, password, ip);

            await client.CloseAsync();

            return new BaseResponse<string>
            {
                StatusCode = Domain.Enums.StatusCode.OK,
                Data = response.@return,
            };
        }

        public async Task<IBaseResponse<string>> Register(string ip)
        {
            var client = new AuthenticationService.ICUTechClient();

            await client.OpenAsync();

            var response = await client
                .RegisterNewCustomerAsync("super_puper_mega_duper_test@test.com", "123456789", "Bob", "Dick", "+373778459852", 373, 2, ip);

            await client.CloseAsync();

            return new BaseResponse<string>
            {
                StatusCode = Domain.Enums.StatusCode.OK,
                Data = response.@return,
            };
        }
    }
}
