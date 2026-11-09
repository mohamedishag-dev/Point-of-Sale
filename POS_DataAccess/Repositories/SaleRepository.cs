using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public DataTable GetAllSales()
        {

            DataTable dtSales = new DataTable();

            string query = @"SELECT Sales.SaleID, Customers.CustomerName, Sales.SubTotal, Sales.Discount, Sales.Tax, 
                                    Sales.PaidAmount, Sales.SaleStatus, Sales.SaleDate, Sales.LastStatusDate, 
                                    Sales.TotalAmount, Sales.Notes, Users.Username, Roles.RoleName
                               FROM Sales INNER JOIN
                                    Customers ON Sales.CustomerID = Customers.CustomerID INNER JOIN
                                    Users ON Sales.UserID = Users.UserID INNER JOIN
                                    Roles ON Users.RoleID = Roles.RoleID AND Users.RoleID = Roles.RoleID;";

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
                            UpdateSaleItem(item);
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
        public bool UpdateSaleItem(SaleItem Item)
        {
            int rowsAffected = 0;

            string query = @"Update SaleItems  
                             SET Quantity = @Quantity
                                 UnitPrice = @UnitPrice
                                 WHERE ItemID = @ItemID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", Item.ItemID);
                        command.Parameters.AddWithValue("@Quantity", Item.Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", Item.UnitPrice);

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
                                AddSaleItem(item);
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
        public int AddSaleItem(SaleItem Item)
        {
            //this function will return the new SaleItem id if succeeded and -1 if not.
            int ItemID = -1;

            string query = @"INSERT INTO SaleItems (SaleID, BatchID, Quantity, UnitPrice)
                             VALUES (@SaleID, @BatchID, @Quantity, @UnitPrice)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", Item.SaleID);
                        command.Parameters.AddWithValue("@BatchID", Item.BatchID);
                        command.Parameters.AddWithValue("@Quantity", Item.Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", Item.UnitPrice);


                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ItemID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return ItemID;
        }
        public int AddPayment(Payment payment)
        {
            int paymentID = -1;

            string query = @"INSERT INTO Payments (SaleID, Amount, PaymentMethod, PaymentDate, UserID, Notes)
                             VALUES (@SaleID, @Amount, @PaymentMethod, @PaymentDate, @UserID, @Notes);
                             SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", payment.SaleID);
                        command.Parameters.AddWithValue("@Amount", payment.Amount);
                        command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                        command.Parameters.AddWithValue("@UserID", payment.UserID);
                        command.Parameters.AddWithValue("@Notes", (object)payment.Notes ?? DBNull.Value);

                        connection.Open();

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            paymentID = insertedID;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return paymentID;
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
                            Items = GetAllSaleItems(saleID)
                        };

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<Payment> GetAllPayments(int SaleID)
        {

            List<Payment> payments = new List<Payment>();

            string query = @"SELECT * FROM Payments
                                WHERE SaleID = @SaleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", SaleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payments.Add(new Payment
                                {
                                    SaleID = (int)reader["SaleID"],
                                    Amount = (int)reader["Amount"],
                                    PaymentMethod = (string)reader["PaymentMethod"],
                                    PaymentDate = (DateTime)reader["PaymentDate"],
                                    UserID = (int)reader["UserID"],
                                    Notes = (string)reader["Notes"]
                                });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return payments;

        }
        public List<SaleItem> GetAllSaleItems(int SaleID)
        {

            List<SaleItem> items = new List<SaleItem>();

            string query = @"SELECT * FROM SaleItems
                                WHERE SaleID = @SaleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", SaleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new SaleItem
                                {
                                    SaleID = (int)reader["SaleID"],
                                    ItemID = (int)reader["ItemID"],
                                    BatchID = (int)reader["BatchID"],
                                    Quantity = (decimal)reader["Quantity"],
                                    UnitPrice = (decimal)reader["UnitPrice"],
                                });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return items;

        }


    }
}

//                    UPDATE Sales
//                    SET PaidAmount = (SELECT SUM(Amount) FROM Payments WHERE SaleID = @SaleID)
//                    WHERE SaleID = @SaleID;



