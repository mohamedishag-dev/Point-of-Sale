using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public DataTable GetAll()
        {

            DataTable dtCategories = new DataTable();

            string query = @"SELECT * FROM Categories;";

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
                            dtCategories.Load(reader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get all categories", ex);
            }

            return dtCategories;

        }

        public int Add(Category category)
        {
            //this function will return the new Category id if succeeded and -1 if not.
            int CategoryID = -1;

            string query = @"INSERT INTO Categories (CategoryName)
                             VALUES (@CategoryName)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CategoryID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to add the category", ex);
            }

            return CategoryID;
        }

        public bool IsExists(int CategoryID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Categories WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

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
                EventViewerLogger.Error("Failed to check if the category exists", ex);
            }

            return isFound;
        }

        public bool Update(Category category)
        {
            int rowsAffected = 0;

            string query = @"Update Categories  
                            SET CategoryName = @CategoryName
                                IsActive = @IsActive
                                WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        command.Parameters.AddWithValue("@IsActive", category.IsActive);


                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to update the category", ex);
                return false;
            }

            return (rowsAffected > 0);

        }

        public bool Deactivate(int categoryID)
        {
            int rowsAffected = 0;

            const string query = "UPDATE Categories SET IsActive = 0 WHERE CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to deactivate the category", ex);
            }
            return (rowsAffected > 0);
        }

        public Category GetByCategoryID(int CategoryID)
        {
            const string query = @"SELECT * FROM Categories WHERE CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Category
                        {
                            CategoryID = (int)reader["CategoryID"],
                            CategoryName = (string)reader["CategoryName"],

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get the category by ID", ex);
                return null;
            }

        }

    }

}
