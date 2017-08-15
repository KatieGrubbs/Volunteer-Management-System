namespace Pre_SemesterAssignment_VMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCenterIdForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Opportunity", "Center_CenterId", "dbo.Center");
            DropIndex("dbo.Opportunity", new[] { "Center_CenterId" });
            RenameColumn(table: "dbo.Opportunity", name: "Center_CenterId", newName: "CenterId");
            AlterColumn("dbo.Opportunity", "CenterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Opportunity", "CenterId");
            AddForeignKey("dbo.Opportunity", "CenterId", "dbo.Center", "CenterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opportunity", "CenterId", "dbo.Center");
            DropIndex("dbo.Opportunity", new[] { "CenterId" });
            AlterColumn("dbo.Opportunity", "CenterId", c => c.Int());
            RenameColumn(table: "dbo.Opportunity", name: "CenterId", newName: "Center_CenterId");
            CreateIndex("dbo.Opportunity", "Center_CenterId");
            AddForeignKey("dbo.Opportunity", "Center_CenterId", "dbo.Center", "CenterId");
        }
    }
}
