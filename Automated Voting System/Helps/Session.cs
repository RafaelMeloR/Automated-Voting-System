using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Automated_Voting_System.Helps
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Session : Attribute, IAuthorizationFilter
    {
       public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var user = filterContext.HttpContext.Items[""];

            if (user != null)
            {
                filterContext.Result=new JsonResult(new {message="Not Authorized"}){ StatusCode=StatusCodes.Status401Unauthorized};
            }
        }
    }
}
