using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OpenFlat.API.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    USER_NAME = table.Column<string>(maxLength: 60, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 60, nullable: false),
                    NAME = table.Column<string>(maxLength: 60, nullable: false),
                    SURNAME = table.Column<string>(maxLength: 60, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    PHONE_MOBILE = table.Column<string>(maxLength: 10, nullable: true),
                    PHONE_HOME = table.Column<string>(maxLength: 10, nullable: true),
                    PHONE_OFFICE = table.Column<string>(maxLength: 10, nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(nullable: true),
                    GENDER = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    USER_ID = table.Column<int>(nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_ROLE_ID",
                table: "USER_ROLES",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_USER_ID",
                table: "USER_ROLES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_USER_NAME",
                table: "USERS",
                column: "USER_NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_ROLES");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
