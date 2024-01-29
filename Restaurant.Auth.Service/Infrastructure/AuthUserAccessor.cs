using Restaurant.Auth.UseCases.Abstractions;
using System.Security.Claims;

namespace Restaurant.Auth.Service.Infrastructure
{
    public class AuthUserAccessor : IAuthUserAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthUserAccessor(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetUserId()
        {
            var user = GetHttpContextUser();

            var userId = user.FindFirstValue("UserId")
                ?? throw new UnauthorizedAccessException("Access token doesn't have an employee Id");

            return new Guid(userId);
        }

        public ClaimsPrincipal GetHttpContextUser()
        {
            var httpContext = _contextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new InvalidOperationException("Http context wasn't founded");
            }

            return httpContext.User;
        }
    }
}
