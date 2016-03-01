namespace GraduateDesignBk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 删除角色创建人 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetRoles", "WhoCreate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "WhoCreate", c => c.String(maxLength: 200));
        }
    }
}
