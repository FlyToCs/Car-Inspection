using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class updateappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerFirstName",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastName",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "محمد", "حسینی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "فاطمه", "شفیعی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "لیلا", "نرده ای" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "علی", "رضایی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "سنا", "محمدی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "نیما", "شاد" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "مینا", "رسولی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "حسین", "اکبری" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "زهرا", "شالی" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OwnerFirstName", "OwnerLastName" },
                values: new object[] { "رامین", "کاظمی" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerFirstName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "Appointments");
        }
    }
}
