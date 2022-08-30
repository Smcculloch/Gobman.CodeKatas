namespace Gobman.CodeKatas.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowPersonNullAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Person", new[] { "AddressId" });
            AlterColumn("dbo.Person", "AddressId", c => c.Guid());
            CreateIndex("dbo.Person", "AddressId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Person", new[] { "AddressId" });
            AlterColumn("dbo.Person", "AddressId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Person", "AddressId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
    }
}
