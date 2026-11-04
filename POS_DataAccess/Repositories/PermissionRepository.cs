using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class PermissionRepository 
    {
        public DataTable GetAll()
        {

            DataTable dtPermissions = new DataTable();

            string query = @"SELECT * FROM Permissions";

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
                                dtPermissions.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtPermissions;

        }

        public bool Update(Permission permission)
        {

            int rowsAffected = 0;

            string query = @"Update Permissions  
                                SET PermissionName = @PermissionName
                              WHERE PermissionID = @PermissionID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PermissionID", permission.ID);
                        command.Parameters.AddWithValue("@PermissionName", permission.PermissionName);

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

        public Permission GetById(int PermissionID)
        {
            const string query = @"SELECT * FROM Permissions WHERE PermissionID = @PermissionID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PermissionID", PermissionID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Permission
                        {
                            ID = (int)reader["PermissionID"],
                            PermissionName = (string)reader["PermissionName"]
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
