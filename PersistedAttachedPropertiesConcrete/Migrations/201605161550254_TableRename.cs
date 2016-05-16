namespace PersistedAttachedPropertiesConcrete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PropertyValueConfigurationInt", newName: "AttachedPropertyValueInt");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AttachedPropertyValueInt", newName: "PropertyValueConfigurationInt");
        }
    }
}
