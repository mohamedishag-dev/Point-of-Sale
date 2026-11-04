using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace POS_DataAccess.Repositories
{
    public class SupplierRepository : IGenericRepository<clsSupplier>
    {
        public bool Delete(int ID)
        {
            int rowsAffected = 0;

            string query = @"Delete Suppliers 
                              WHERE SupplierID = @SupplierID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierID", ID);

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

        public DataTable GetAll()
        {

            DataTable dtSuppliers = new DataTable();

            string query = @"SELECT * FROM Suppliers;";

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
                                dtSuppliers.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtSuppliers;

        }

        public int Add(clsSupplier supplier)
        {
            //this function will return the new Supplier id if succeeded and -1 if not.
            int SupplierID = -1;

            string query = @"INSERT INTO Suppliers (SupplierName, Phone ,Email ,Address ,City ,OpeningBalance)
                             VALUES (@SupplierName, @Phone, @Email, @Address, @City, @OpeningBalance)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@Phone", supplier.Phone);
                        command.Parameters.AddWithValue("@Email", (object)supplier.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                        command.Parameters.AddWithValue("@City", (object)supplier.City ?? DBNull.Value);
                        command.Parameters.AddWithValue("@City", supplier.OpeningBalance);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SupplierID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return SupplierID;
        }

        public bool IsExists(int supplierID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Suppliers WHERE SupplierID = @SupplierID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
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
            }
            catch (Exception ex)
            {
                isFound = false;
            }

            return isFound;
        }

        public bool Update(clsSupplier supplier)
        {
            int rowsAffected = 0;

            string query = @"Update Suppliers  
                            SET SupplierName = @SupplierName, 
                                Phone = @Phone, 
                                Email = @Email, 
                                Address = @Address, 
                                City = @City, 
                                OpeningBalance = @OpeningBalance 
                                WHERE SupplierID = @SupplierID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@Phone", supplier.Phone);
                        command.Parameters.AddWithValue("@Email", (object)supplier.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@City", supplier.City);
                        command.Parameters.AddWithValue("@OpeningBalance", supplier.OpeningBalance);

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

        public clsSupplier GetById(int SupplierID)
        {
            const string query = @"SELECT * FROM Suppliers
                                    WHERE SupplierID = @SupplierID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", SupplierID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new clsSupplier
                        {
                          
                            SupplierID = (int)reader["SupplierID"],
                            SupplierName = (string)reader["Suppliername"],
                            Phone = reader["Phone"] as string,
                            Email = reader["Email"] as string,
                            Address = reader["Address"] as string,
                            City = reader["City"] as string,
                            OpeningBalance = (decimal)reader["OpeningBalance"],
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

