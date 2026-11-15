using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public DataTable GetAllExpenses()
        {
            DataTable dtExpenses = new DataTable();

            const string query = @"SELECT e.ExpenseID, e.ExpenseType, e.ExpenseDate, e.Amount, e.Notes, u.Username
                                   FROM Expenses e
                                   INNER JOIN Users u ON e.UserID = u.UserID
                                   ORDER BY e.ExpenseDate DESC, e.ExpenseID DESC;";

            try
            {
                using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        dtExpenses.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get all Expenses", ex);
            }

            return dtExpenses;
        }

        public int AddExpense(Expense expense)
        {
            int ExpenseID = -1;
            const string query = @"INSERT INTO Expenses (ExpenseType, ExpenseDate, Amount, Notes, UserID)
                                   VALUES (@ExpenseType, @ExpenseDate, @Amount, @Notes, @UserID);
                                   SELECT SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", expense.UserID);
                    command.Parameters.AddWithValue("@ExpenseType", (object)expense.ExpenseType ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Notes", (object)expense.Notes ?? DBNull.Value);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        ExpenseID = insertedID;
                    }

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to add the Expense", ex);
            }
            return ExpenseID;

        }

        public bool DeleteExpense(int expenseID)
        {
            int rowsAffected = 0;
            const string query = "DELETE FROM Expenses WHERE ExpenseID = @ExpenseID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExpenseID", expenseID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to delete the Expense", ex);
            }

                 
            return (rowsAffected > 0);
        }

        public bool UpdateExpense(Expense expense)
        {
            int rowsAffected = 0;

            const string query = @"UPDATE Expenses
                                   SET ExpenseType = @ExpenseType,
                                       ExpenseDate = @ExpenseDate,
                                       Amount      = @Amount,
                                       Notes       = @Notes
                                 WHERE ExpenseID   = @ExpenseID;";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExpenseID", expense.ExpenseID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to update the Expense", ex);
            }

            return (rowsAffected > 0);
        }


    }
}
