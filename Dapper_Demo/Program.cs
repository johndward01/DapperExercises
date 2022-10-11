using Dapper_Demo;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connectionString);

var productRepo = new ProductRepo(conn);

//productRepo.CreateProduct("NEW PRODUCT!!!", 29.99, 10);
//productRepo.UpdateProductName(940, "UPDATED PRODUCT!!!");
productRepo.DeleteProduct(940);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine();
    Console.WriteLine();
}