using System.Web.Mvc;

namespace DataLib.Extensions
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles): base()
        {
            Roles = string.Join(",", roles);
        }
    }
}