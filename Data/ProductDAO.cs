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

        internal int Delete(int ID)
        {
            // access the db
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string sqlQuery = "DELETE FROM dbo.Products WHERE Id = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.VarChar, 50).Value = ID;

                connection.Open();

                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }

        public ProductModel FetchProduct(int ID)
        {
            // access the db
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string sqlQuery = "SELECT * FROM dbo.Products WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = ID;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ProductModel product = new ProductModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);

                        Enum.TryParse(reader.GetString(2), out Category category);
                        product.Category = category;

                        product.ImageSrc = reader.GetString(3);
                        product.Price = (float)reader.GetDecimal(4);
                        product.Description = reader.GetString(5);
                        product.Rating = reader.GetInt32(6);
                    }
                }
                return product;
            }
        }

        public int CreateOrUpdate(ProductModel productModel)
        {
            // access the db
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string sqlQuery = "";
                if (productModel.Id <= 0)
                {
                    // Create product
                    sqlQuery = "INSERT INTO dbo.Products Values(@Name, @Category, @ImageSrc, @Price, @Description, @Rating)";
                }
                else
                {
                    // Edit product
                    sqlQuery = "UPDATE dbo.Products SET Name = @Name, Category = @Category, ImageSrc = @ImageSrc, Price = @Price, Description = @Description, Rating = @Rating WHERE Id = @Id"; 
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 50).Value = productModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50).Value = productModel.Name;
                command.Parameters.Add("@Category", System.Data.SqlDbType.VarChar, 30).Value = productModel.Category;
                command.Parameters.Add("@ImageSrc", System.Data.SqlDbType.VarChar, 500).Value = productModel.ImageSrc;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Float, 10).Value = productModel.Price;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 2000).Value = productModel.Description;
                command.Parameters.Add("@Rating", System.Data.SqlDbType.Int, 1).Value = productModel.Rating;

                connection.Open();

                int newId = command.ExecuteNonQuery();

                return newId;
            }
        }
    }
}