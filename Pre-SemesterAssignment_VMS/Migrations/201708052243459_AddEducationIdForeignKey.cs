namespace Pre_SemesterAssignment_VMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducationIdForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Volunteer", "Education_EducationId", "dbo.Education");
            DropIndex("dbo.Volunteer", new[] { "Education_EducationId" });
            RenameColumn(table: "dbo.Volunteer", name: "Education_EducationId", newName: "EducationId");
            AlterColumn("dbo.Volunteer", "EducationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Volunteer", "EducationId");
            AddForeignKey("dbo.Volunteer", "EducationId", "dbo.Education", "EducationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteer", "EducationId", "dbo.Education");
            DropIndex("dbo.Volunteer", new[] { "EducationId" });
            AlterColumn("dbo.Volunteer", "EducationId", c => c.Int());
            RenameColumn(table: "dbo.Volunteer", name: "EducationId", newName: "Education_EducationId");
            CreateIndex("dbo.Volunteer", "Education_EducationId");
            AddForeignKey("dbo.Volunteer", "Education_EducationId", "dbo.Education", "EducationId");
        }
    }
}
