using System.Web.Mvc;

namespace WebSite.Extensions
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles): base()
        {
            Roles = string.Join(",", roles);
        }
    }
}