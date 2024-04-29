using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreVezba.Migrations
{
    public partial class WorkOnEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "1cbab369-5947-46a9-9dc8-de569944d28d");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "4cb32af8-0924-4f48-a515-1083840a3e59");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "e6360754-3ba3-4f75-b776-a9a48d9bb215");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "0295b78f-d6a1-4f89-bf58-a52efd4f2b8e");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2d71e22a-921f-4fea-9b36-bd2c6289357c");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5f637f8e-681e-40a8-affa-26290bf015e6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8923d006-e79c-42e1-8b75-4167f100d180");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "cb3e630e-6251-446c-ad4e-d128259b662f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f9c2535a-ff09-4208-bd67-5fb57c052df0");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "28db3586-cc20-4ade-9302-5bc9788cde9f");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "721482ec-9e5d-4cee-85b4-1c7cbabba830");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "14695ab7-5ac9-4de7-b51b-2da09dbc8deb");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "c277209e-f3ac-4057-9942-51ef3f98d6c9");

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "Active", "Balance", "CompanyId", "Currency", "Type", "UserId" },
                values: new object[,]
                {
                    { "1c896ba8-90b7-4890-9ef1-f08eb0d3202a", true, 200.0, null, 1, 0, "2" },
                    { "50fffd8d-0689-4fa8-a52d-0fd7dfa5ae5d", true, 100000.0, "dabaed46-5bcc-49d5-a9c6-91496f62acf6", 1, 1, null },
                    { "575068b2-b381-442d-8b4d-5134513dc5a0", true, 40000.0, "e3649b51-8804-496a-8c98-e8f24bff5827", 1, 1, null },
                    { "d37c6b0e-c306-4c75-a6e6-1908400163f9", true, 15000.0, null, 2, 0, "1" },
                    { "ea7ff9d7-b0d2-4141-b726-64f58e4fe7a4", true, 500.0, null, 1, 0, "3" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 16, 12, 35, 49, 706, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 16, 12, 35, 50, 318, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 16, 12, 35, 50, 802, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankAccountId", "Email", "Name" },
                values: new object[,]
                {
                    { "dabaed46-5bcc-49d5-a9c6-91496f62acf6", "50fffd8d-0689-4fa8-a52d-0fd7dfa5ae5d", "company2@example.com", "Company 2" },
                    { "e3649b51-8804-496a-8c98-e8f24bff5827", "575068b2-b381-442d-8b4d-5134513dc5a0", "company1@example.com", "Company 1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { "25fc9bad-a853-4b4c-8dba-774f2df7d145", "dabaed46-5bcc-49d5-a9c6-91496f62acf6", "Description for Product 5", "Product 5", 12L, 35f },
                    { "4243e6a5-9f1e-4b06-8739-70e91062c163", "e3649b51-8804-496a-8c98-e8f24bff5827", "Description for Product 1", "Product 1", 10L, 20f },
                    { "572cabab-7f0e-42a0-8352-e76bf9c6d542", "dabaed46-5bcc-49d5-a9c6-91496f62acf6", "Description for Product 4", "Product 4", 8L, 25f },
                    { "897a694c-7e25-4b46-994d-2f3bee105af3", "dabaed46-5bcc-49d5-a9c6-91496f62acf6", "Description for Product 6", "Product 6", 18L, 40f },
                    { "b4c437e0-f0f8-4cf4-a7d7-07a35765e7be", "e3649b51-8804-496a-8c98-e8f24bff5827", "Description for Product 2", "Product 2", 15L, 30f },
                    { "d2b10626-91ae-4ffe-bc0e-3738f80e9c9c", "e3649b51-8804-496a-8c98-e8f24bff5827", "Description for Product 3", "Product 3", 20L, 25f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "1c896ba8-90b7-4890-9ef1-f08eb0d3202a");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "d37c6b0e-c306-4c75-a6e6-1908400163f9");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "ea7ff9d7-b0d2-4141-b726-64f58e4fe7a4");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "25fc9bad-a853-4b4c-8dba-774f2df7d145");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4243e6a5-9f1e-4b06-8739-70e91062c163");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "572cabab-7f0e-42a0-8352-e76bf9c6d542");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "897a694c-7e25-4b46-994d-2f3bee105af3");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b4c437e0-f0f8-4cf4-a7d7-07a35765e7be");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d2b10626-91ae-4ffe-bc0e-3738f80e9c9c");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "dabaed46-5bcc-49d5-a9c6-91496f62acf6");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "e3649b51-8804-496a-8c98-e8f24bff5827");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "50fffd8d-0689-4fa8-a52d-0fd7dfa5ae5d");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: "575068b2-b381-442d-8b4d-5134513dc5a0");

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "Active", "Balance", "CompanyId", "Currency", "Type", "UserId" },
                values: new object[,]
                {
                    { "14695ab7-5ac9-4de7-b51b-2da09dbc8deb", true, 100000.0, "721482ec-9e5d-4cee-85b4-1c7cbabba830", 1, 1, null },
                    { "1cbab369-5947-46a9-9dc8-de569944d28d", true, 200.0, null, 1, 0, "2" },
                    { "4cb32af8-0924-4f48-a515-1083840a3e59", true, 500.0, null, 1, 0, "3" },
                    { "c277209e-f3ac-4057-9942-51ef3f98d6c9", true, 40000.0, "28db3586-cc20-4ade-9302-5bc9788cde9f", 1, 1, null },
                    { "e6360754-3ba3-4f75-b776-a9a48d9bb215", true, 15000.0, null, 2, 0, "1" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 15, 22, 21, 31, 711, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 15, 22, 21, 32, 213, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "RegisteredOn",
                value: new DateTime(2024, 4, 15, 22, 21, 32, 782, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankAccountId", "Email", "Name" },
                values: new object[,]
                {
                    { "28db3586-cc20-4ade-9302-5bc9788cde9f", "c277209e-f3ac-4057-9942-51ef3f98d6c9", "company1@example.com", "Company 1" },
                    { "721482ec-9e5d-4cee-85b4-1c7cbabba830", "14695ab7-5ac9-4de7-b51b-2da09dbc8deb", "company2@example.com", "Company 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { "0295b78f-d6a1-4f89-bf58-a52efd4f2b8e", "721482ec-9e5d-4cee-85b4-1c7cbabba830", "Description for Product 6", "Product 6", 18L, 40f },
                    { "2d71e22a-921f-4fea-9b36-bd2c6289357c", "28db3586-cc20-4ade-9302-5bc9788cde9f", "Description for Product 1", "Product 1", 10L, 20f },
                    { "5f637f8e-681e-40a8-affa-26290bf015e6", "721482ec-9e5d-4cee-85b4-1c7cbabba830", "Description for Product 4", "Product 4", 8L, 25f },
                    { "8923d006-e79c-42e1-8b75-4167f100d180", "28db3586-cc20-4ade-9302-5bc9788cde9f", "Description for Product 3", "Product 3", 20L, 25f },
                    { "cb3e630e-6251-446c-ad4e-d128259b662f", "28db3586-cc20-4ade-9302-5bc9788cde9f", "Description for Product 2", "Product 2", 15L, 30f },
                    { "f9c2535a-ff09-4208-bd67-5fb57c052df0", "721482ec-9e5d-4cee-85b4-1c7cbabba830", "Description for Product 5", "Product 5", 12L, 35f }
                });
        }
    }
}
