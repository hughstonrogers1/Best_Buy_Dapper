using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Best_buy_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection; //Encapsulation 
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * From Products;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("Insert Into Products (Name, Price, CategoryID) Values (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        //Update data
        public void UpdateProductName(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }

        //Delete data
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
        }
    }
}
