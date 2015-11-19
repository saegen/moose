using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;


namespace DataLib.Models.Identity
{
    // You can add profile data for the user by adding more properties to your DataLibUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class DataLibUser : IdentityUser
    {
        public DataLibUser() : base() { }

        public DataLibUser(string userName) : base(userName) { }

        //Ej nödvändig
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DataLibUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class DataLibRole : IdentityRole
    {
        public DataLibRole() : base() { }
        public DataLibRole(string roleName) : base(roleName) { }
    }

    public class DataModelContext : IdentityDbContext<DataLibUser>
    {
        public DataModelContext(string nameOrConnectionString = "DataModelCodeFirst", bool throwIfV1Schema = false)
            //: base("DataModelCodeFirst", throwIfV1Schema: false)
            : base(nameOrConnectionString, throwIfV1Schema)
        { }

    }
}