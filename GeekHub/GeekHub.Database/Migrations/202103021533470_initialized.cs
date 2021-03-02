namespace GeekHub.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        ProductCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ProductCategory_ID)
                .Index(t => t.ProductCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductCategory_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ProductCategory_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
