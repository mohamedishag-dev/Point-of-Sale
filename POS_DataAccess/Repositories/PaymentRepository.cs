using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public int AddPayment(Payment payment)
        {
            int paymentID = -1;

            string query = @"INSERT INTO Payments (SaleID, Amount, PaymentMethod, PaymentDate, UserID, Notes)
                             VALUES (@SaleID, @Amount, @PaymentMethod, @PaymentDate, @UserID, @Notes);
                             SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SaleID", payment.SaleID);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@UserID", payment.UserID);
                    command.Parameters.AddWithValue("@Notes", (object)payment.Notes ?? DBNull.Value);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        paymentID = insertedID;

                    }

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to add the payment", ex);
            }

            return paymentID;
        }

        public decimal GetTotalPaid(int saleID)
        {
            const string query = "SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE SaleID = @SaleID;";

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SaleID", saleID);
                connection.Open();
                return Convert.ToDecimal(command.ExecuteScalar());
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
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get the payments", ex);
                return null;
            }

            return payments;

        }


    }
}

