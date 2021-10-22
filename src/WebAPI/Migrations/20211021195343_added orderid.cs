using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class addedorderid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDET_Orders_OrderId",
                table: "OrderDET");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDET",
                table: "OrderDET");

            migrationBuilder.DropIndex(
                name: "IX_OrderDET_OrderId",
                table: "OrderDET");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDET",
                newName: "OrderId1");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDET",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId1",
                table: "OrderDET",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDET",
                table: "OrderDET",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDET_OrderId1",
                table: "OrderDET",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDET_Orders_OrderId1",
                table: "OrderDET",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDET_Orders_OrderId1",
                table: "OrderDET");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDET",
                table: "OrderDET");

            migrationBuilder.DropIndex(
                name: "IX_OrderDET_OrderId1",
                table: "OrderDET");

            migrationBuilder.RenameColumn(
                name: "OrderId1",
                table: "OrderDET",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDET",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderDET",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDET",
                table: "OrderDET",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDET_OrderId",
                table: "OrderDET",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDET_Orders_OrderId",
                table: "OrderDET",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
