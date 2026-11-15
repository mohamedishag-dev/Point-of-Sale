using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public DataTable GetAllSuppliers()
        {
            DataTable dtSuppliers = new DataTable();

            string query = @"SELECT SupplierID, SupplierName, Phone, Email, City, Address, OpeningBalance
                               FROM Suppliers;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtSuppliers.Load(reader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get all suppliers", ex);
            }

            return dtSuppliers;

        }

        public bool IsExists(int supplierID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Suppliers WHERE SupplierID = @SupplierID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to check if the supplier exists", ex);
            }

            return isFound;
        }

        public int AddSupplier(Supplier supplier)
        {
            //this function will return the new supplier id if succeeded and -1 if not.
            int supplierID = -1;

            string query = @"INSERT INTO Suppliers (SupplierName, Phone, Email, City, Address, OpeningBalance)
                             VALUES (@SupplierName, @Phone, @Email, @City, @Address, @OpeningBalance)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone);
                    command.Parameters.AddWithValue("@Email", supplier.Email);
                    command.Parameters.AddWithValue("@City", supplier.City);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@OpeningBalance", supplier.OpeningBalance);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        supplierID = insertedID;
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to add supplier", ex);
            }

            return supplierID;
        }

        public bool IsExists(string supplierName)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Suppliers WHERE SupplierName = @SupplierName";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierName", supplierName);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to check if the supplier exists", ex);
            }

            return isFound;
        }

        public bool DeleteSupplier(int supplierID)
        {
            int rowsAffected = 0;

            string query = @"Delete Suppliers 
                              WHERE SupplierID = @SupplierID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierID);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to delete supplier", ex);
            }

            return (rowsAffected > 0);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            int rowsAffected = 0;

            string query = @"Update Suppliers  
                                SET SupplierName = @SupplierName, 
                                    Phone = @Phone, 
                                    Email = @Email, 
                                    City = @City, 
                                    Address = @Address, 
                                    OpeningBalance = @OpeningBalance
                                    WHERE SupplierID = @SupplierID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone);
                    command.Parameters.AddWithValue("@Email", (object)supplier.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@City", supplier.City);
                    command.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@OpeningBalance", supplier.OpeningBalance);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to update supplier", ex);
            }

            return (rowsAffected > 0);

        }

        public Supplier GetSupplierByID(int supplierID)
        {
            const string query = @"SELECT SupplierID, SupplierName, Phone, Email, City, Address, OpeningBalance
                                     FROM Suppliers WHERE SupplierID = @SupplierID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Supplier
                        {
                            SupplierID = (int)reader["SupplierID"],
                            SupplierName = (string)reader["SupplierName"],
                            Phone = (string)reader["Phone"],
                            Email = reader["Email"] as string,
                            City = (string)reader["City"],
                            Address = reader["Address"] as string,
                            OpeningBalance = (decimal)reader["OpeningBalance"]

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get supplier", ex);
                return null;
            }

        }

    }

}
