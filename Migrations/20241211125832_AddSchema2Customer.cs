using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiSchemaDB_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddSchema2Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "Schema3",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "Schema2",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "Schema1",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Schema3",
                newName: "Schema3Customer");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Schema2",
                newName: "Schema2Customer");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Schema1",
                newName: "Schema1Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Schema3Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Schema3Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Schema3Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Schema3Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Schema2Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Schema2Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Schema2Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Schema1Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Schema1Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Schema1Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schema3Customer",
                table: "Schema3Customer",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schema2Customer",
                table: "Schema2Customer",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schema1Customer",
                table: "Schema1Customer",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Schema3Customer_Email",
                table: "Schema3Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Schema2Customer_Email",
                table: "Schema2Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Schema1Customer_Email",
                table: "Schema1Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schema3Customer",
                table: "Schema3Customer");

            migrationBuilder.DropIndex(
                name: "IX_Schema3Customer_Email",
                table: "Schema3Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schema2Customer",
                table: "Schema2Customer");

            migrationBuilder.DropIndex(
                name: "IX_Schema2Customer_Email",
                table: "Schema2Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schema1Customer",
                table: "Schema1Customer");

            migrationBuilder.DropIndex(
                name: "IX_Schema1Customer_Email",
                table: "Schema1Customer");

            migrationBuilder.EnsureSchema(
                name: "Schema1");

            migrationBuilder.EnsureSchema(
                name: "Schema2");

            migrationBuilder.EnsureSchema(
                name: "Schema3");

            migrationBuilder.RenameTable(
                name: "Schema3Customer",
                newName: "Customers",
                newSchema: "Schema3");

            migrationBuilder.RenameTable(
                name: "Schema2Customer",
                newName: "Customers",
                newSchema: "Schema2");

            migrationBuilder.RenameTable(
                name: "Schema1Customer",
                newName: "Customers",
                newSchema: "Schema1");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Schema3",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                schema: "Schema3",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                schema: "Schema3",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Schema3",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "Schema2",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Schema2",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Schema2",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Schema1",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Schema1",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Schema1",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "Schema3",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "Schema2",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "Schema1",
                table: "Customers",
                column: "CustomerID");
        }
    }
}
