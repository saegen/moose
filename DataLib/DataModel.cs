namespace DataLib
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.Content;
    using Models.Identity;

    //3 stegs arv. DataModel:DataModelContext:Identity<
    public partial class DataModel : DataModelContext
    {
        public DataModel() : base("DataModelCodeFirst", throwIfV1Schema: false)
            //: base("name=DataModelCodeFirst")
        {
        }

        public virtual DbSet<EditableContent> Content { get; set; }

        //public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        //public virtual DbSet<DataLibRole> DataLibRoles { get; set; }
        //public virtual DbSet<DataLibUser> DataLibUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                    
            modelBuilder.Entity<EditableContent>()
                .HasKey<string>(e => e.ElementId)
                .Map(m => m.ToTable("Content"));

            //modelBuilder.Entity<AspNetRole>()
            //    .HasMany(e => e.AspNetUsers)
            //    .WithMany(e => e.AspNetRoles)
            //    .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUser>().HasKey<string>(u => u.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
