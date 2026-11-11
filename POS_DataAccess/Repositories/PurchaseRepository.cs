using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public DataTable GetAllPurchases()
        {
            DataTable dtPurchases = new DataTable();

            string query = @"SELECT Purchases.PurchaseID, Suppliers.SupplierName, Users.Username, Purchases.PurchaseDate,  Purchases.PaidAmount,
                                    Purchases.TotalAmount, Purchases.TotalAmount - Purchases.PaidAmount AS Remaining
                              FROM  Purchases
                              INNER JOIN Suppliers ON Purchases.SupplierID = Suppliers.SupplierID
                              INNER JOIN Users ON Purchases.UserID = Users.UserID
                              ORDER BY Purchases.PurchaseDate DESC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPurchases.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtPurchases;
        }

        public int AddPurchase(Purchase purchase)
        {
            //this function will return the new purchase id if succeeded and -1 if not.
            int PurchaseID = -1;

            string query = @"INSERT INTO Purchases (SupplierID, UserID, PurchaseDate, PaidAmount, TotalAmount)
                                 VALUES (@SupplierID, @UserID, @PurchaseDate, @PaidAmount, @TotalAmount)
                                 SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierID", purchase.SupplierID);
                        command.Parameters.AddWithValue("@UserID", purchase.UserID);
                        command.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
                        command.Parameters.AddWithValue("@PaidAmount", purchase.PaidAmount);
                        command.Parameters.AddWithValue("@TotalAmount", purchase.TotalAmount);


                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PurchaseID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return PurchaseID;
        }

        public bool IsPurchaseExists(int purchaseID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Purchases WHERE PurchaseID = @PurchaseID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseID", purchaseID);

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

        public bool UpdatePurchase(Purchase purchase)
        {

            int rowsAffected = 0;

            string query = @"Update Purchases  
                                    SET SupplierID = @SupplierID,
                                        UserID = @UserID,
                                        PaidAmount = @PaidAmount,
                                        TotalAmount = @TotalAmount
                                  WHERE PurchaseID = @PurchaseID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PurchaseID", purchase.PurchaseID);
                        command.Parameters.AddWithValue("@SupplierID", purchase.SupplierID);
                        command.Parameters.AddWithValue("@UserID", purchase.UserID);
                        command.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
                        command.Parameters.AddWithValue("@PaidAmount", purchase.PaidAmount);
                        command.Parameters.AddWithValue("@TotalAmount", purchase.TotalAmount);

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

        public Purchase GetPurchaseByID(int purchaseID)
        {
            const string query = @"SELECT PurchaseID, SupplierID, UserID, PurchaseDate, PaidAmount, TotalAmount
                                     FROM Purchases WHERE PurchaseID = @PurchaseID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PurchaseID", purchaseID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Purchase
                        {
                            PurchaseID = (int)reader["PurchaseID"],
                            SupplierID = (int)reader["SupplierID"],
                            UserID = (int)reader["UserID"],
                            PurchaseDate = (DateTime)reader["PurchaseDate"],
                            PaidAmount = (decimal)reader["PaidAmount"],
                            TotalAmount = (decimal)reader["TotalAmount"]
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
