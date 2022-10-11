using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Demo;
internal interface IProductRepo
{
    public void CreateProduct(string newName, double newPrice, int newCategoryID);
    public IEnumerable<Product> GetAllProducts();
    public void UpdateProductName(int newProductID, string newUpdatedName);
    public void DeleteProduct(int productID);
}
