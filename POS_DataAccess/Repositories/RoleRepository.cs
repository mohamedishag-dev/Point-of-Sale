using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
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
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to add the role", ex);
            }

            return RoleID;
        }

        public DataTable GetAllRoles()
        {
            DataTable dtRoles = new DataTable();
            string query = @"SELECT RoleID, RoleName FROM Roles";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtRoles);
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get the roles", ex);
                return null;
            }
            return dtRoles;
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

                    using (SqlDataReader reader = command.ExecuteReader())
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
                EventViewerLogger.Error("Failed to get the roles", ex);
                return null;
            }

        }

        public bool IsExists(int roleID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Roles WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to check if the role exists", ex);
                isFound = false;
            }

            return isFound;
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
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", role.RoleID);
                    command.Parameters.AddWithValue("@RoleName", role.RoleName);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to update the role", ex);
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
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to delete the role", ex);
            }
            return (rowsAffected > 0);
        }

    }

}

