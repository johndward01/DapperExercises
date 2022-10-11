using Dapper;
using System.Data;

namespace Dapper_Demo;
internal class ProductRepo
{
    private readonly IDbConnection _connection;

    //constructor - and will do some setup work for us
    public ProductRepo(IDbConnection connection)
    {
        _connection = connection;
    }

    //Create data
    public void CreateProduct(string newName, double newPrice, int newCategoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
            new { name = newName, price = newPrice, categoryID = newCategoryID });
    }

    //Read data
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    //Update data
    public void UpdateProductName(int id, string newUpdatedName)
    {
        _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
            new { updatedName = newUpdatedName, productID = id });
    }

    //Delete data
    public void DeleteProduct(int productID)
    {
        //_connection.Execute("DELETE FROM reviews WHERE ProductID = @product_id;",
        //    new { product_id = productID });

        //_connection.Execute("DELETE FROM sales WHERE ProductID = @product_id;",
        //   new { product_id = productID });

        _connection.Execute("DELETE FROM products WHERE ProductID = @product_id;",
           new { product_id = productID });
    }

    public Product GetProduct(int productID)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;",
            new { id = productID });
    }
}
