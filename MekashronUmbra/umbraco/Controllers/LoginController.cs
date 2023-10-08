using MekashronTest.Services.Login;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPoco.fastJSON;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace MekashronUmbra.umbraco.Controllers
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginController : Umbraco.Cms.Web.Common.Controllers.UmbracoApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            var credentials = JsonConvert.DeserializeObject<UserCredentials>(HttpContext.Request.GetRawBodyString());
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (credentials is null || ip is null)
                return Problem();

            var res = await _loginService.Login(credentials.Username, credentials.Password, ip);

            if(res.StatusCode == MekashronTest.Domain.Enums.StatusCode.OK)
            {
                var resp = JsonConvert.DeserializeAnonymousType(res.Data, new { ResultCode = 0, ResultMessage = "" });
                if (resp.ResultCode == -1)
                    return Problem(resp.ResultMessage);

                var info = JsonConvert.DeserializeAnonymousType(res.Data, new
                {
                    FirstName = "",
                    LastName = "",
                    Mobile = "",
                    Email = ""
                });

                return Content(JsonConvert.SerializeObject(info));
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var res = await _loginService.Register(ip);

            if (res.StatusCode == MekashronTest.Domain.Enums.StatusCode.OK)
            {
                var resp = JsonConvert.DeserializeAnonymousType(res.Data, new { ResultCode = 0, ResultMessage = "" });
                if (resp.ResultCode < 0)
                    return Problem(resp.ResultMessage);

                return Content(resp.ResultMessage);
            }
            else
            {
                return Problem();
            }
        }
    }
}
