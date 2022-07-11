namespace ConsoleApplication1.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("People", "PersonCity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("People", "PersonCity");
        }
    }
}
