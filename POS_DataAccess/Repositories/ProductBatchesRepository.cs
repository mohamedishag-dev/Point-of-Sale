using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class ProductBatchesRepository : IProductBatchesRepository
    {
        public DataTable GetAll()
        {

            DataTable dtBaths = new DataTable();

            string query = @"SELECT * FROM ProductBatches";

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
                                dtBaths.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtBaths;

        }

        public bool DeleteBath(int BathID)
        {
            int rowsAffected = 0;

            string query = @"Delete ProductBatches 
                              WHERE BathID = @BathID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BathID", BathID);

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

        public int AddNewBath(ProductBatches Bath)
        {
            //this function will return the new Bath id if succeeded and -1 if not.
            int BathID = -1;

            string query = @"INSERT INTO ProductBatches (ProductID, BatchNumber, ProductionDate, ExpiryDate,
                                    ProductCost,Quantity, CreatedAt, CreatedBy)
                             VALUES (@ProductID, @BatchNumber, @ProductionDate, @ExpiryDate,
                                    @ProductCost, @Quantity, @CreatedAt, @CreatedBy)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", Bath.ProductID);
                        command.Parameters.AddWithValue("@BatchNumber", Bath.BatchNumber);
                        command.Parameters.AddWithValue("@ProductionDate",(object)Bath.ProductionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ExpiryDate", Bath.ExpiryDate);
                        command.Parameters.AddWithValue("@ProductCost", Bath.ProductCost);
                        command.Parameters.AddWithValue("@Quantity", Bath.Quantity);
                        command.Parameters.AddWithValue("@CreatedAt", Bath.CreatedAt);
                        command.Parameters.AddWithValue("@CreatedBy", Bath.CreatedBy);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            BathID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return BathID;
        }

        public bool UpdateBath(ProductBatches Bath)
        {

            int rowsAffected = 0;

            string query = @"Update ProductBatches  
                                SET ProductID = @ProductID,
                                    BatchNumber = @BatchNumber,
                                    ProductionDate = @ProductionDate,
                                    ExpiryDate = @ExpiryDate,
                                    ProductCost = @ProductCost,
                                    Quantity = @Quantity,
                              WHERE BathID = @BathID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ProductID", Bath.ProductID);
                        command.Parameters.AddWithValue("@BatchNumber", Bath.BatchNumber);
                        command.Parameters.AddWithValue("@ProductionDate", (object)Bath.ProductionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ExpiryDate", Bath.ExpiryDate);
                        command.Parameters.AddWithValue("@ProductCost", Bath.ProductCost);
                        command.Parameters.AddWithValue("@Quantity", Bath.Quantity);


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

        public bool IsBathExists(int BathID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM ProductBatches WHERE BathID = @BathID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BathID", BathID);

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

        public ProductBatches GetBathById(int BathID)
        {
            const string query = @"SELECT * FROM ProductBatches WHERE BathID = @BathID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BathID", BathID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new ProductBatches
                        {
                         
                            BatchID = (int)reader["BatchID"],
                            ProductID = (int)reader["ProductID"],
                            BatchNumber =   (string)reader["BatchNumber"],
                            ProductionDate   = (DateTime)reader["ProductionDate"],
                            ExpiryDate=(DateTime)reader["ExpiryDate"],
                            ProductCost = (decimal)reader["ProductCost"],
                            Quantity = (decimal)reader["Quantity"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
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
