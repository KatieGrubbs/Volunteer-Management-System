namespace Pre_SemesterAssignment_VMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availability",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.AvailabilityId);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 35),
                        LastName = c.String(nullable: false, maxLength: 35),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(maxLength: 2),
                        Address_ZipCode = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 255),
                        EmergencyContact_Name = c.String(maxLength: 70),
                        EmergencyContact_Address_Street = c.String(),
                        EmergencyContact_Address_City = c.String(),
                        EmergencyContact_Address_State = c.String(maxLength: 2),
                        EmergencyContact_Address_ZipCode = c.String(),
                        EmergencyContact_PhoneNumber = c.String(),
                        EmergencyContact_EmailAddress = c.String(maxLength: 255),
                        DriversLicenseOnFile = c.Boolean(nullable: false),
                        SSCardOnFile = c.Boolean(nullable: false),
                        Education_EducationId = c.Int(),
                    })
                .PrimaryKey(t => t.VolunteerId)
                .ForeignKey("dbo.Education", t => t.Education_EducationId)
                .Index(t => t.Education_EducationId);
            
            CreateTable(
                "dbo.License",
                c => new
                    {
                        LicenseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LicenseId);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        EducationLevel = c.String(),
                    })
                .PrimaryKey(t => t.EducationId);
            
            CreateTable(
                "dbo.Interest",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InterestId);
            
            CreateTable(
                "dbo.Center",
                c => new
                    {
                        CenterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(maxLength: 2),
                        Address_ZipCode = c.String(),
                        PrimaryContact_Name = c.String(maxLength: 70),
                        PrimaryContact_Address_Street = c.String(),
                        PrimaryContact_Address_City = c.String(),
                        PrimaryContact_Address_State = c.String(maxLength: 2),
                        PrimaryContact_Address_ZipCode = c.String(),
                        PrimaryContact_PhoneNumber = c.String(),
                        PrimaryContact_EmailAddress = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CenterId);
            
            CreateTable(
                "dbo.Opportunity",
                c => new
                    {
                        OpportunityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Center_CenterId = c.Int(),
                    })
                .PrimaryKey(t => t.OpportunityId)
                .ForeignKey("dbo.Center", t => t.Center_CenterId)
                .Index(t => t.Center_CenterId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.VolunteerAvailability",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        AvailabilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.AvailabilityId })
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Availability", t => t.AvailabilityId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.AvailabilityId);
            
            CreateTable(
                "dbo.VolunteerLicense",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        LicenseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.LicenseId })
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.License", t => t.LicenseId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.LicenseId);
            
            CreateTable(
                "dbo.VolunteerInterest",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.InterestId })
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Interest", t => t.InterestId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.InterestId);
            
            CreateTable(
                "dbo.VolunteerCenter",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.CenterId })
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Center", t => t.CenterId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.VolunteerSkill",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.SkillId })
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolunteerSkill", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.VolunteerSkill", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.VolunteerCenter", "CenterId", "dbo.Center");
            DropForeignKey("dbo.VolunteerCenter", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.Opportunity", "Center_CenterId", "dbo.Center");
            DropForeignKey("dbo.VolunteerInterest", "InterestId", "dbo.Interest");
            DropForeignKey("dbo.VolunteerInterest", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.Volunteer", "Education_EducationId", "dbo.Education");
            DropForeignKey("dbo.VolunteerLicense", "LicenseId", "dbo.License");
            DropForeignKey("dbo.VolunteerLicense", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.VolunteerAvailability", "AvailabilityId", "dbo.Availability");
            DropForeignKey("dbo.VolunteerAvailability", "VolunteerId", "dbo.Volunteer");
            DropIndex("dbo.VolunteerSkill", new[] { "SkillId" });
            DropIndex("dbo.VolunteerSkill", new[] { "VolunteerId" });
            DropIndex("dbo.VolunteerCenter", new[] { "CenterId" });
            DropIndex("dbo.VolunteerCenter", new[] { "VolunteerId" });
            DropIndex("dbo.VolunteerInterest", new[] { "InterestId" });
            DropIndex("dbo.VolunteerInterest", new[] { "VolunteerId" });
            DropIndex("dbo.VolunteerLicense", new[] { "LicenseId" });
            DropIndex("dbo.VolunteerLicense", new[] { "VolunteerId" });
            DropIndex("dbo.VolunteerAvailability", new[] { "AvailabilityId" });
            DropIndex("dbo.VolunteerAvailability", new[] { "VolunteerId" });
            DropIndex("dbo.Opportunity", new[] { "Center_CenterId" });
            DropIndex("dbo.Volunteer", new[] { "Education_EducationId" });
            DropTable("dbo.VolunteerSkill");
            DropTable("dbo.VolunteerCenter");
            DropTable("dbo.VolunteerInterest");
            DropTable("dbo.VolunteerLicense");
            DropTable("dbo.VolunteerAvailability");
            DropTable("dbo.Skill");
            DropTable("dbo.Opportunity");
            DropTable("dbo.Center");
            DropTable("dbo.Interest");
            DropTable("dbo.Education");
            DropTable("dbo.License");
            DropTable("dbo.Volunteer");
            DropTable("dbo.Availability");
        }
    }
}
