namespace Gobman.CodeKatas.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnePersonToManyAddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Person", new[] { "AddressId" });
            AddColumn("dbo.Address", "PersonId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Address", "PersonId");
            AddForeignKey("dbo.Address", "PersonId", "dbo.Person", "PersonId", cascadeDelete: true);
            DropColumn("dbo.Person", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "AddressId", c => c.Guid());
            DropForeignKey("dbo.Address", "PersonId", "dbo.Person");
            DropIndex("dbo.Address", new[] { "PersonId" });
            DropColumn("dbo.Address", "PersonId");
            CreateIndex("dbo.Person", "AddressId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "AddressId");
        }
    }
}
