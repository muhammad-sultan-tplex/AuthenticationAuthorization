using Newtonsoft.Json;
using System.Security.Claims;

namespace AuthenticationAuthorization.AppSession
{
    public class AppSession: IAppSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Email {
            get
            {
                 return _httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            }
        }

        public string RoleName {
            get
            {
                return _httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            }
        }
    }
}
