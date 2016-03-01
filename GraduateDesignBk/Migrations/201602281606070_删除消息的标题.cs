namespace GraduateDesignBk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 删除消息的标题 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Mesgs", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mesgs", "Title", c => c.String(maxLength: 200));
        }
    }
}
