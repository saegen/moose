namespace DataLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ElementId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        View = c.String(),
                    })
                .PrimaryKey(t => t.ElementId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Content");
        }
    }
}
