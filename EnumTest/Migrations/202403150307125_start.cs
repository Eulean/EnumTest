namespace EnumTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        GenderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropTable("dbo.Users");
            DropTable("dbo.Genders");
        }
    }
}
