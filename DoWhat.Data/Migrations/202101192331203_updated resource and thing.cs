namespace DoWhat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedresourceandthing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "CatagoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assignment", "CatagoryId");
            AddForeignKey("dbo.Assignment", "CatagoryId", "dbo.Catagory", "CatagoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "CatagoryId", "dbo.Catagory");
            DropIndex("dbo.Assignment", new[] { "CatagoryId" });
            DropColumn("dbo.Assignment", "CatagoryId");
        }
    }
}
