using POS_DataAccess.Interfaces;
using POS_DataAccess.LogDAL;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        public DataTable GetAllPermissions()
        {

            DataTable dtPermissions = new DataTable();

            string query = @"SELECT PermissionID, PermissionName FROM Permissions";

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
                            dtPermissions.Load(reader);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get the Permissions", ex);

            }

            return dtPermissions;

        }

        public List<Permission> GetAllPermissionsByRole(int roleID)
        {
            List<Permission> permissions = new List<Permission>();
            string query = @"SELECT p.PermissionID, p.PermissionName FROM Permissions p
                              INNER JOIN RolePermissions ON p.PermissionID = RolePermissions.PermissionID
                              WHERE RolePermissions.RoleID = @RoleID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissions.Add(new Permission
                            {
                                ID = (int)reader["PermissionID"],
                                PermissionName = (string)reader["PermissionName"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.Error("Failed to get the Permissions", ex);
            }
            return permissions;
        }

    }
}
