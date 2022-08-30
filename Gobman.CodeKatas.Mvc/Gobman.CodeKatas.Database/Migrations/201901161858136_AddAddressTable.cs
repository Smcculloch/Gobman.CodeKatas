namespace Gobman.CodeKatas.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        StreetAddress1 = c.String(maxLength: 200),
                        StreetAddress2 = c.String(maxLength: 200),
                        PostalCode = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Person", "AddressId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Person", "AddressId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Person", new[] { "AddressId" });
            DropColumn("dbo.Person", "AddressId");
            DropTable("dbo.Address");
        }
    }
}
