using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistence.Migrations
{
    /// <inheritdoc />
    public partial class udpate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionDetailId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "collectionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collectionId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_collectionDetails_Collections_collectionId",
                        column: x => x.collectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CollectionDetailId",
                table: "Books",
                column: "CollectionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_collectionDetails_collectionId",
                table: "collectionDetails",
                column: "collectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_collectionDetails_CollectionDetailId",
                table: "Books",
                column: "CollectionDetailId",
                principalTable: "collectionDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_collectionDetails_CollectionDetailId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "collectionDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_CollectionDetailId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CollectionDetailId",
                table: "Books");
        }
    }
}
