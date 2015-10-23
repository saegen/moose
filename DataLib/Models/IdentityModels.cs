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

        public DataLibUser(string userName,string id) : base(userName) { Id = id; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CS0114:Dont hide Base class field",Justification ="Only just for testing")]
        public string Id {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }

    public class DataLibRole : IdentityRole
    {
        public DataLibRole(string roleName) : base(roleName) { }
    }

    public class DataModelContext : IdentityDbContext<DataLibUser>
    {
        public DataModelContext(string nameOrConnectionString = "DataModelCodeFirst", bool throwIfV1Schema = false)
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