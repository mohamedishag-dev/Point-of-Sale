using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ISaleItemsRepository _items;
        public SaleRepository(ISaleItemsRepository items) => _items = items;


        public bool SaveChanges()
        {

            return false;
        }

        public DataTable GetAllSales()
        {

            DataTable dtSales = new DataTable();

            string query = @"SELECT Sales.SaleID, Customers.CustomerName, Sales.SubTotal, Sales.Discount, Sales.Tax, 
                                    Sales.PaidAmount, Sales.SaleStatus, Sales.SaleDate, Sales.LastStatusDate, 
                                    Sales.TotalAmount, Sales.Notes, Users.Username, Roles.RoleName
                               FROM Sales INNER JOIN
                                    Customers ON Sales.CustomerID = Customers.CustomerID INNER JOIN
                                    Users ON Sales.UserID = Users.UserID INNER JOIN
                                    Roles ON Users.RoleID = Roles.RoleID;";

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
                                dtSales.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtSales;

        }

        public bool IsExists(int saleID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Sales WHERE SaleID = @SaleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", saleID);

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

        public int AddNewSale(Sale sale)
        {
            //this function will return the new Sale id if succeeded and -1 if not.
            int SaleID = -1;

            string query = @"INSERT INTO Sales (CustomerID, UserID, SubTotal, Discount, Tax,
                                    PaidAmount, SaleStatus, SaleDate, LastStatusDate, Notes)
                             VALUES (@CustomerID, @UserID, @SubTotal, @Discount, @Tax,
                                    @PaidAmount, @SaleStatus, @SaleDate, @LastStatusDate, @Notes)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                        command.Parameters.AddWithValue("@UserID", sale.UserID);
                        command.Parameters.AddWithValue("@SubTotal", sale.SubTotal);
                        command.Parameters.AddWithValue("@Discount", sale.Discount);
                        command.Parameters.AddWithValue("@Tax", sale.Tax);
                        command.Parameters.AddWithValue("@PaidAmount", sale.PaidAmount);
                        command.Parameters.AddWithValue("@SaleStatus", sale.SaleStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", sale.LastStatusDate);
                        command.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                        command.Parameters.AddWithValue("@Notes", (object)sale.Notes ?? DBNull.Value);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SaleID = insertedID;
                            foreach (var item in sale.Items)
                            {
                                item.SaleID = SaleID;
                                _items.AddItem(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return SaleID;
        }

        public bool UpdateSale(Sale sale)
        {
            int rowsAffected = 0;

            string query = @"Update Sales  
                            SET SubTotal = @SubTotal,
                                Discount = @Discount,
                                PaidAmount = @PaidAmount,
                                SaleStatus = @SaleStatus,
                                LastStatusDate = @LastStatusDate,
                                Notes = @Notes
                                WHERE SaleID = @SaleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", sale.SaleID);
                        command.Parameters.AddWithValue("@SubTotal", sale.SubTotal);
                        command.Parameters.AddWithValue("@Discount", sale.Discount);
                        command.Parameters.AddWithValue("@Tax", sale.Tax);
                        command.Parameters.AddWithValue("@PaidAmount", sale.PaidAmount);
                        command.Parameters.AddWithValue("@SaleStatus", sale.SaleStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", sale.LastStatusDate);
                        command.Parameters.AddWithValue("@Notes", (object)sale.Notes ?? DBNull.Value);

                        connection.Open();
                        foreach (var item in sale.Items)
                        {
                            _items.UpdateItem(item);
                        }
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

        public Sale GetBySaleID(int saleID)
        {
            const string query = @"SELECT * FROM Sales WHERE SaleID = @SaleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SaleID", saleID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Sale
                        {
                            SaleID = (int)reader["SaleID"],
                            CustomerID = (int)reader["CustomerID"],
                            UserID = (int)reader["UserID"],
                            SubTotal = (decimal)reader["SubTotal"],
                            Discount = (decimal)reader["Discount"],
                            Tax = (decimal)reader["Tax"],
                            PaidAmount = (decimal)reader["PaidAmount"],
                            SaleStatus = (byte)reader["SaleStatus"],
                            SaleDate = (DateTime)reader["SaleDate"],
                            LastStatusDate = (DateTime)reader["LastStatusDate"],
                            Notes = (string)reader["Notes"] as string,
                            Items = _items.GetAllItems(saleID)
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



