namespace PersistedAttachedPropertiesConcrete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttachedProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 128),
                        Type = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyValueConfigurationInt",
                c => new
                    {
                        PropertyId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => new { t.PropertyId, t.EntityId });
            
            CreateTable(
                "dbo.AttachedPropertyValueLong",
                c => new
                    {
                        PropertyId = c.Int(nullable: false),
                        EntityId = c.Long(nullable: false),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => new { t.PropertyId, t.EntityId });
            
            CreateTable(
                "dbo.DomainEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DomainEntities");
            DropTable("dbo.AttachedPropertyValueLong");
            DropTable("dbo.PropertyValueConfigurationInt");
            DropTable("dbo.AttachedProperties");
        }
    }
}
