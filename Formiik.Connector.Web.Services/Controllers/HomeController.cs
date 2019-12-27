using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Web.Services.AppCode.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Formiik.Connector.Web.Services.Controllers
{
    public class HomeController : Controller
    {
        private AppInfo _appInfo;
        public HomeController(IOptions<AppInfo> appInfo)
        {
            _appInfo = appInfo.Value;
        }
        
        public string Index()
        {
            return $"{_appInfo.ApplicationName} v{_appInfo.Version} {_appInfo.DeployDate} - GGJ";
        }

        [HttpGet]
        public JsonResult UserInfo()
        {
            try
            {
                string authorization = Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authorization))
                {
                    authorization = authorization.Replace("Bearer ", string.Empty, StringComparison.OrdinalIgnoreCase);
                }
                
                JwtSecurityTokenHandler handler;
                JwtSecurityToken tokenS;

                handler = new JwtSecurityTokenHandler();
                tokenS = handler.ReadJwtToken(authorization);

                var claimEmail = tokenS.Claims.First(c =>
                    string.Equals(c.Type.ToLower(), JwtElements.EMAIL, StringComparison.InvariantCultureIgnoreCase)
                    || string.Equals(c.Type.ToLower(), JwtElements.UPN, StringComparison.InvariantCultureIgnoreCase));

                var claimName = tokenS.Claims.First(c =>
                    string.Equals(c.Type.ToLower(), JwtElements.NAME, StringComparison.InvariantCultureIgnoreCase));

                UserInfoAzureAD info = new UserInfoAzureAD();
                info.userPrincipalName = claimEmail.Value;
                info.displayName = claimName.Value;
                
                return this.Json(info);
            }
            catch (Exception e)
            {
                throw new AuthenticationException("No se pudo autenticar.");
            }
        }
    }
}
