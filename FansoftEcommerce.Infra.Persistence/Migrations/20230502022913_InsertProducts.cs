using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FansoftEcommerce.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories([Name]) VALUES ('Alimento'), ('Higiene'), ('Informática')");
            migrationBuilder.Sql("INSERT INTO Products ([Name], Price_Currency, Price_Amount, Sku, CategoryId) VALUES('Picanha do Ladrão', 'R$', 110.5, 'XX1234QQIIUUCTF', 1);");
            migrationBuilder.Sql("INSERT INTO Products ([Name], Price_Currency, Price_Amount, Sku, CategoryId) VALUES('Sorvete', 'R$', 35.99, 'ZZ1234ERIIUUCTF', 1);");
            migrationBuilder.Sql("INSERT INTO Products ([Name], Price_Currency, Price_Amount, Sku, CategoryId) VALUES('Fralda Pampers', 'R$', 99.99, 'LL4321QWSIUUCTF', 2);");
            migrationBuilder.Sql("INSERT INTO Products ([Name], Price_Currency, Price_Amount, Sku, CategoryId) VALUES('Mouse Microsoft', 'R$', 150.99, 'XG3214QWSIUUIY6', 3);");
            migrationBuilder.Sql("INSERT INTO Products ([Name], Price_Currency, Price_Amount, Sku, CategoryId) VALUES('Teclado Logitech', 'R$', 80.99, 'XG3214QWSIUUIY7', 3);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Categories");
            migrationBuilder.Sql("TRUNCATE TABLE Products");
        }
    }
}
