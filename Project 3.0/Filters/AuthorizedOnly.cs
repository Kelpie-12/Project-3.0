using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Filters
{
    public class AuthorizedOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");

            if (userId != null)
                return;

            context.Result = new UnauthorizedResult();
        }
    }
}
