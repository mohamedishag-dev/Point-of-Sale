using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public DataTable GetAllProducts()
        {

            DataTable dtProducts = new DataTable();

            string query = @"SELECT Products.ProductID, Products.SKU, Products.Barcode, Products.ProductName, Products.Price, Units.UnitName,
                                    (SELECT ISNULL(SUM(Quantity), 0) FROM ProductBatches 
                                        WHERE ProductBatches.ProductID = Products.ProductID 
                                              AND ExpiryDate > CAST(GETDATE() AS DATE))AS StockQuantity
                               FROM Products INNER JOIN
                                    Units ON Products.UnitID = Units.UnitID INNER JOIN
                                    Categories ON Products.CategoryID = Categories.CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtProducts.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtProducts;

        }

        public bool DeleteProduct(int productID)
        {
            int rowsAffected = 0;

            string query = @"Delete Products 
                              WHERE ProductID = @ProductID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productID);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;

            }
            return (rowsAffected > 0);
        }

        public int AddNewProduct(Product product)
        {
            //this function will return the new Product id if succeeded and -1 if not.
            int ProductID = -1;

            string query = @"INSERT INTO Products (CategoryID, UnitID, ProductName, SKU, Barcode,
                                     Price, Description, CreatedAt, ImagePath, CreatedBy)
                             VALUES (@CategoryID, @UnitID, @ProductName, @SKU, @Barcode,
                                     @Price, @Description, @CreatedAt,  @ImagePath, @CreatedBy)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        command.Parameters.AddWithValue("@UnitID", product.UnitID);
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@SKU", product.SKU);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                        command.Parameters.AddWithValue("@CreatedBy", product.CreatedBy);

                        command.Parameters.AddWithValue("@Barcode", (object)product.Barcode ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)product.ImagePath ?? DBNull.Value);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ProductID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ProductID;
        }

        public bool UpdateProduct(Product product)
        {

            int rowsAffected = 0;

            string query = @"Update Products  
                                SET CategoryID = @CategoryID,
                                    UnitID = @UnitID,
                                    ProductName = @ProductName,
                                    SKU = @SKU,
                                    Barcode = @Barcode,
                                    Price = @Price,
                                    Description = @Description,
                                    ImagePath = @ImagePath,
                              WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        command.Parameters.AddWithValue("@UnitID", product.UnitID);
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@SKU", product.SKU);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Description", product.Description);
                       
                        command.Parameters.AddWithValue("@Barcode", (object)product.Barcode ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)product.ImagePath ?? DBNull.Value);


                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return (rowsAffected > 0);

        }

        public bool IsProductExists(int productID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Products WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }

            return isFound;
        }

        public Product GetProductById(int productID)
        {
            const string query = @"SELECT * FROM Products WHERE ProductID = @ProductID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            CategoryID = (int)reader["CategoryID"],
                            UnitID = (int)reader["UnitID"],
                            ProductName = (string)reader["ProductName"],
                            SKU = (string)reader["SKU"],
                            Barcode = (string)reader["Barcode"] as string,
                            Price = (int)reader["Price"],
                            Description = (string)reader["Description"] as string,
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            ImagePath = reader["ImagePath"] as string,
                            CreatedBy = (int)reader["CreatedBy"],
                      
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
