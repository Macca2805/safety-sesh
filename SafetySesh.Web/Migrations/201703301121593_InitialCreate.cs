namespace SafetySesh.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SafetyDiscussions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Observer = c.String(),
                        Date = c.DateTime(),
                        Location = c.String(),
                        Collegue = c.String(),
                        Subject = c.String(),
                        Outcomes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SafetyDiscussions");
        }
    }
}
