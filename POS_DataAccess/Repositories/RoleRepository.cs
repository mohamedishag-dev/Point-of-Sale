using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class RoleRepository 
    {
        public bool Delete(int ID)
        {
            int rowsAffected = 0;

            string query = @"Delete Roles 
                              WHERE RoleID = @RoleID ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", ID);

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

            DataTable dtRoles = new DataTable();

            string query = @"SELECT U.RoleID, FullName = U.FirstName+' '+U.LastName, U.Rolename,
                                    U.Phone, U.Email, U.Address, Roles.RoleName, U.IsActive
                               FROM Roles U INNER JOIN
                          RoleRoles ON U.RoleID = RoleRoles.RoleID INNER JOIN
                              Roles ON RoleRoles.RoleID = Roles.RoleID";

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
                                dtRoles.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dtRoles;

        }

        public int Add(Role role)
        {
            //this function will return the new Role id if succeeded and -1 if not.
            int RoleID = -1;

            string query = @"INSERT INTO Roles (RoleName)
                             VALUES (RoleName) 
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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

        public bool Update(Role Role)
        {

            int rowsAffected = 0;

            string query = @"Update Roles  
                                SET RoleName = @RoleName
                              WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", Role.RoleID);
                        command.Parameters.AddWithValue("@RoleName", Role.RoleName);

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

        public bool IsExists(int RoleID)
        {
            bool isFound = false;

            string query = "SELECT Found=1 FROM Roles WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", RoleID);

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

        public Role GetById(int RoleID)
        {
            const string query = @"SELECT * FROM Roles WHERE RoleID = @RoleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", RoleID);
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

    }

}

