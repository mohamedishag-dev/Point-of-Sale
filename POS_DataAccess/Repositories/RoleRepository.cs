using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        public int AddRole(Role role)
        {
            //this function will return the new Role id if succeeded and -1 if not.
            int RoleID = -1;

            string query = @"INSERT INTO Roles (RoleName)
                             VALUES (RoleName) 
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", role.RoleName);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            RoleID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return RoleID;
        }

        public bool UpdateRole(Role role)
        {

            int rowsAffected = 0;

            string query = @"Update Roles  
                                SET RoleName = @RoleName
                              WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", role.RoleID);
                        command.Parameters.AddWithValue("@RoleName", role.RoleName);

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

        public bool DeleteRole(int roleID)
        {
            int rowsAffected = 0;

            string query = @"Delete Roles WHERE RoleID = @RoleID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", roleID);

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

        public Role GetById(int roleID)
        {
            const string query = @"SELECT * FROM Roles WHERE RoleID = @RoleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Role
                        {
                            RoleID = (int)reader["RoleID"],
                            RoleName = (string)reader["RoleName"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool IsExists(int roleID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Roles WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", roleID);

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

    }

}

