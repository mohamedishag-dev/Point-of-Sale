using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool Delete(int ID)
        {
            int rowsAffected = 0;

            string query = @"Delete Users 
                              WHERE UserID = @UserID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ID);

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

            DataTable dtUsers = new DataTable();

            string query = @"SELECT U.UserID, U.FullName, U.Username, U.Phone,
                                    U.Email, U.Address, Roles.RoleName, U.IsActive
                               FROM Users U INNER JOIN
                              Roles ON U.RoleID = Roles.RoleID";

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
                                dtUsers.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtUsers;

        }

        public int AddNewUser(User user)
        {
            //this function will return the new User id if succeeded and -1 if not.
            int UserID = -1;

            string query = @"INSERT INTO Users (FullName, Username, PasswordHash, Phone,
                                   Email, Address, CreatedAt, ImagePath, IsActive, RoleID)
                             VALUES (@FullName, @Username, @PasswordHash, @Phone,
                                   @Email, @Address, @CreatedAt, @ImagePath, @IsActive, @RoleID)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive);
                        command.Parameters.AddWithValue("@RoleID", user.RoleID);

                        command.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)user.Address ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)user.ImagePath ?? DBNull.Value);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            UserID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return UserID;
        }

        public bool UpdateUser(User user)
        {

            int rowsAffected = 0;

            string query = @"Update Users  
                            SET FullName = @FullName, 
                                Username = @Username, 
                                Phone = @Phone, 
                                Email = @Email, 
                                Email = @Email, 
                                Address = @Address, 
                                IsActive = @IsActive
                                RoleID = @RoleID
                                WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", user.Address);
                        command.Parameters.AddWithValue("@ImagePath", (object)user.ImagePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive);
                        command.Parameters.AddWithValue("@RoleID", user.RoleID);


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

        public bool IsUserExists(int userID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

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

        public bool IsUserExists(string Username)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Users WHERE Username = @Username";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);

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
       
        public User GetUserById(int userID)
        {
            const string query = @"SELECT UserID, FullName, Username ,Phone, Email, Address, ImagePath, CreatedAt, IsActive, RoleID 
                                     FROM Users WHERE UserID = @UserID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            FullName = (string)reader["FullName"],
                            Username = (string)reader["Username"],
                            Phone = reader["Phone"] as string,
                            Email = reader["Email"] as string,
                            Address = reader["Address"] as string,
                            ImagePath = reader["ImagePath"] as string,
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"],
                            RoleID = (int)reader["RoleID"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool ChangePassword(int UserID, string NewPassword)
        {

            int rowsAffected = 0;

            string query = @"Update Users  
                            SET PasswordHash = @NewPassword
                            WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                return false;

            }
           

            return (rowsAffected > 0);
        }

        public User GetByUsernameAndPassword(string Username, string Password)
        {
            const string query = @"SELECT UserID, FullName, Username,Phone, Email, Address, ImagePath, IsActive, RoleID 
                                     FROM Users WHERE Username = @Username AND PasswordHash = @Password;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            FullName = (string)reader["FullName"],
                            Username = (string)reader["Username"],
                            Phone = reader["Phone"] as string,
                            Email = reader["Email"] as string,
                            Address = reader["Address"] as string,
                            ImagePath = reader["ImagePath"] as string,
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"],
                            RoleID = (int)reader["RoleID"]
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