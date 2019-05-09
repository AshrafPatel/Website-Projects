namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rotation",
                c => new
                    {
                        PKey = c.Int(nullable: false),
                        RotationName = c.String(nullable: false),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        Supervisor = c.String(nullable: false),
                        RKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Student", t => t.PKey)
                .Index(t => t.PKey);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        PostalCode = c.String(maxLength: 7),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        Telephone = c.String(nullable: false, maxLength: 30),
                        ProgramType = c.String(),
                        ProgramName = c.String(nullable: false),
                        InstitutionalName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rotation", "PKey", "dbo.Student");
            DropIndex("dbo.Rotation", new[] { "PKey" });
            DropTable("dbo.Student");
            DropTable("dbo.Rotation");
        }
    }
}
