using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortressAuth.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class createrefreshtokenuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "TB_USER");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "TB_USER",
                newName: "DS_ROLE");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "TB_USER",
                newName: "DS_PASSWORD_HASH");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USER",
                newName: "DS_NAME");

            migrationBuilder.RenameColumn(
                name: "IsInactive",
                table: "TB_USER",
                newName: "TG_INACTIVE");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TB_USER",
                newName: "DS_EMAIL");

            migrationBuilder.RenameColumn(
                name: "DhInclusion",
                table: "TB_USER",
                newName: "DH_INCLUSION");

            migrationBuilder.RenameColumn(
                name: "DhChange",
                table: "TB_USER",
                newName: "DH_CHANGE");

            migrationBuilder.AlterColumn<bool>(
                name: "TG_INACTIVE",
                table: "TB_USER",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "TB_REFRESH_TOKEN_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DS_TOKEN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DH_EXPIRES_AT_UTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TG_REVOKED = table.Column<int>(type: "int", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TG_INACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    DH_INCLUSION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DH_CHANGE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REFRESH_TOKEN_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_REFRESH_TOKEN_USER_TB_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_REFRESH_TOKEN_USER_DS_TOKEN",
                table: "TB_REFRESH_TOKEN_USER",
                column: "DS_TOKEN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_REFRESH_TOKEN_USER_UserId",
                table: "TB_REFRESH_TOKEN_USER",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_REFRESH_TOKEN_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER");

            migrationBuilder.RenameTable(
                name: "TB_USER",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TG_INACTIVE",
                table: "Users",
                newName: "IsInactive");

            migrationBuilder.RenameColumn(
                name: "DS_ROLE",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "DS_PASSWORD_HASH",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "DS_NAME",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DS_EMAIL",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DH_INCLUSION",
                table: "Users",
                newName: "DhInclusion");

            migrationBuilder.RenameColumn(
                name: "DH_CHANGE",
                table: "Users",
                newName: "DhChange");

            migrationBuilder.AlterColumn<bool>(
                name: "IsInactive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
