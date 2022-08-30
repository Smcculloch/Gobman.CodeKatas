namespace Gobman.CodeKatas.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Person");
        }
    }
}
