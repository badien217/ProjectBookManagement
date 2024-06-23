using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistence.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_collectionDetails_CollectionDetailId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_collectionDetails_Collections_collectionId",
                table: "collectionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_collectionDetails",
                table: "collectionDetails");

            migrationBuilder.RenameTable(
                name: "collectionDetails",
                newName: "CollectionDetails");

            migrationBuilder.RenameIndex(
                name: "IX_collectionDetails_collectionId",
                table: "CollectionDetails",
                newName: "IX_CollectionDetails_collectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionDetails",
                table: "CollectionDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CollectionDetails_CollectionDetailId",
                table: "Books",
                column: "CollectionDetailId",
                principalTable: "CollectionDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionDetails_Collections_collectionId",
                table: "CollectionDetails",
                column: "collectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CollectionDetails_CollectionDetailId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionDetails_Collections_collectionId",
                table: "CollectionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionDetails",
                table: "CollectionDetails");

            migrationBuilder.RenameTable(
                name: "CollectionDetails",
                newName: "collectionDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionDetails_collectionId",
                table: "collectionDetails",
                newName: "IX_collectionDetails_collectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_collectionDetails",
                table: "collectionDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_collectionDetails_CollectionDetailId",
                table: "Books",
                column: "CollectionDetailId",
                principalTable: "collectionDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_collectionDetails_Collections_collectionId",
                table: "collectionDetails",
                column: "collectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
