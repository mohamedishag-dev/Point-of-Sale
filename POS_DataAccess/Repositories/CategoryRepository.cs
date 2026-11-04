using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool Deactivate(int categoryID)
        {
            int rowsAffected = 0;

            const string query = "UPDATE Categories SET IsActive = 0 WHERE CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                throw;

            }
            return (rowsAffected > 0);
        }

        public DataTable GetAll()
        {

            DataTable dtCategories = new DataTable();

            string query = @"SELECT * FROM Categories;";

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
                                dtCategories.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

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
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                throw;
            }

            return CategoryID;
        }

        public bool IsExists(int CategoryID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Categories WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                return false;
            }

            return (rowsAffected > 0);

        }

        public Category GetByCategoryID(int CategoryID)
        {
            const string query = @"SELECT * FROM Categories WHERE CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                throw;
            }

        }


    }

}
