using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;


namespace DataLib.Models
{
    // You can add profile data for the user by adding more properties to your DataLibUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class DataLibUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DataLibUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }


    public class DataModelContext : IdentityDbContext<DataLibUser>
    {
        public DataModelContext(string nameOrConnectionString, bool throwIfV1Schema)
            //: base("DataModelCodeFirst", throwIfV1Schema: false)
            : base(nameOrConnectionString, throwIfV1Schema)
        {
        }

        //static DataModelContext()
        //{
        //    // Set the database intializer which is run once during application start
        //    // This seeds the database with admin user credentials and admin role
        //   // Database.SetInitializer<DataModelContext>(new ApplicationDbInitializer());
        //}

        //public static DataModelContext Create()
        //{
        //    return new DataModelContext();
        //}
    }
}