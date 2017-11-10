using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picbook.Repository.EntityFramework.Migrations
{
    public partial class Blabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CreatedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    MobilNumber = table.Column<string>(type: "varchar(21)", unicode: false, maxLength: 21, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    UserName = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Account",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    MobileSizeURL = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    OriginalSizeURL = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    WebSizeURL = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Album",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "ntext", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ImageId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Image",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_AccountID",
                table: "Album",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AlbumId",
                table: "Image",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AccountId",
                table: "Rating",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ImageId",
                table: "Rating",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
