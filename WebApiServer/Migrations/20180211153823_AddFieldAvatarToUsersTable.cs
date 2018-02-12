namespace WebApiServer.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    
    public partial class AddFieldAvatarToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Avatar",
                "Users",
                "varchar(255)",
                nullable: false, defaultValue: "0.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Avatar",
                "Users");
        }
    }
}
