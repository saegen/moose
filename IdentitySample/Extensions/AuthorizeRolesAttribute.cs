using System.Web.Mvc;

namespace IdentitySample.Extensions
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles): base()
        {
            Roles = string.Join(",", roles);
        }
    }
}