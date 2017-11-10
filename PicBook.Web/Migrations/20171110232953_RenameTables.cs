using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PicBook.Web.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_ApplicationUsers_AccountId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentText_ApplicationUsers_AccountId",
                table: "ContentText");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentText_Languages_ImageId",
                table: "ContentText");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Content_AlbumId",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentText",
                table: "ContentText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "ContentText",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_AlbumId",
                table: "Images",
                newName: "IX_Images_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentText_ImageId",
                table: "Ratings",
                newName: "IX_Ratings_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentText_AccountId",
                table: "Ratings",
                newName: "IX_Ratings_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Content_AccountId",
                table: "Albums",
                newName: "IX_Albums_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_ApplicationUsers_AccountId",
                table: "Albums",
                column: "AccountId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUsers_AccountId",
                table: "Ratings",
                column: "AccountId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Images_ImageId",
                table: "Ratings",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_ApplicationUsers_AccountId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUsers_AccountId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Images_ImageId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "ContentText");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ImageId",
                table: "ContentText",
                newName: "IX_ContentText_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_AccountId",
                table: "ContentText",
                newName: "IX_ContentText_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AlbumId",
                table: "Languages",
                newName: "IX_Languages_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_AccountId",
                table: "Content",
                newName: "IX_Content_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentText",
                table: "ContentText",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ApplicationUsers_AccountId",
                table: "Content",
                column: "AccountId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentText_ApplicationUsers_AccountId",
                table: "ContentText",
                column: "AccountId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentText_Languages_ImageId",
                table: "ContentText",
                column: "ImageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Content_AlbumId",
                table: "Languages",
                column: "AlbumId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
