namespace GraduateDesignBk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 增加消息类型 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesgs", "msgType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesgs", "msgType");
        }
    }
}
