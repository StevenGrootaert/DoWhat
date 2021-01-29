namespace DoWhat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkeynull : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thing", "CatagoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Thing", "Heading", c => c.String(nullable: false));
            CreateIndex("dbo.Thing", "CatagoryId");
            //AddForeignKey("dbo.Thing", "CatagoryId", "dbo.Catagory", "CatagoryId", cascadeDelete: true);
            DropColumn("dbo.Thing", "SubHeading");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Thing", "SubHeading", c => c.String(maxLength: 300));
            DropForeignKey("dbo.Thing", "CatagoryId", "dbo.Catagory");
            DropIndex("dbo.Thing", new[] { "CatagoryId" });
            AlterColumn("dbo.Thing", "Heading", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Thing", "CatagoryId");
        }
    }
}
