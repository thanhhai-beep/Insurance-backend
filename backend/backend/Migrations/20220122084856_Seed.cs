using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<float>(type: "real", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.empId);
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "empId", "Phone", "address", "age", "birthday", "email", "firstName", "lastName", "password", "role", "salary", "username" },
                values: new object[] { 1, "0837418189", "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk", 20, new DateTime(2002, 11, 30, 13, 45, 0, 0, DateTimeKind.Unspecified), "dohai30112002@gmail.com", "Đỗ Văn", "Thanh Hải", "111", 1, 0f, "thanhhai" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "empId", "Phone", "address", "age", "birthday", "email", "firstName", "lastName", "password", "role", "salary", "username" },
                values: new object[] { 2, "0837418189", "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk", 20, new DateTime(2002, 11, 30, 13, 45, 0, 0, DateTimeKind.Unspecified), "haido30112002@gmail.com", "Đỗ", "Hải", "222", 2, 0f, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
