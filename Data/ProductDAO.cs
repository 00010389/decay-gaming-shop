using decay_gaming_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace decay_gaming_shop.Data
{
    internal class ProductDAO
    {
        private string connectionStr = @"Data Source=database-decay-gaming-shop.cjoteoum6u9n.ap-northeast-1.rds.amazonaws.com,1433;Initial Catalog=decay_gaming_shop;User ID=admin;Password=decay12345";
        // performs all CRUD and other operations on the db.
        
        public List<ProductModel> FetchAll()
        {
            List<ProductModel> returnList = new List<ProductModel>();

            // access the db
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string sqlQuery = "SELECT * FROM dbo.Products";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader =  command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a new product object and add it to the list.
                        ProductModel product = new ProductModel();
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);

                        Enum.TryParse(reader.GetString(2), out Category category);
                        product.Category = category;

                        product.ImageSrc = reader.GetString(3);
                        product.Price = (float)reader.GetDecimal(4);
                        product.Description = reader.GetString(5);
                        product.Rating = reader.GetInt32(6);

                        returnList.Add(product);
                    }
                }
            }

            return returnList;
        }
    }
}