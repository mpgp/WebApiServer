// --------------------------------------------------------------------------------------------------------------------
// <copyright file="20180116143308_AddTableUsersTokens.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the AddTableUsersTokens type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// The add_table_ users_ tokens.
    /// </summary>
    public partial class AddTableUsersTokens : Migration
    {
        /// <summary>
        /// The up.
        /// </summary>
        /// <param name="migrationBuilder">
        /// The migration builder.
        /// </param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                                              .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTokens", x => x.Id);
                });
        }

        /// <summary>
        /// The down.
        /// </summary>
        /// <param name="migrationBuilder">
        /// The migration builder.
        /// </param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersTokens");
        }
    }
}