using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class SaleItemsRepository : ISaleItemsRepository
    {
        public int AddSaleItem(SaleItem Item)
        {
            //this function will return the new SaleItem id if succeeded and -1 if not.
            int ItemID = -1;

            string query = @"INSERT INTO SaleItems (SaleID, BatchID, Quantity, UnitPrice)
                             VALUES (@SaleID, @BatchID, @Quantity, @UnitPrice)
                             SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", Item.SaleID);
                        command.Parameters.AddWithValue("@BatchID", Item.BatchID);
                        command.Parameters.AddWithValue("@Quantity", Item.Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", Item.UnitPrice);


                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ItemID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return ItemID;
        }

        public bool UpdateSaleItem(SaleItem Item)
        {
            int rowsAffected = 0;

            string query = @"Update SaleItems  
                             SET Quantity = @Quantity
                                 UnitPrice = @UnitPrice
                                 WHERE ItemID = @ItemID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", Item.ItemID);
                        command.Parameters.AddWithValue("@Quantity", Item.Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", Item.UnitPrice);

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

        public SaleItem GetBySaleItemID(int ItemID)
        {
            const string query = @"SELECT * FROM SaleItems WHERE ItemID = @ItemID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", ItemID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new SaleItem
                        {
                            ItemID = (int)reader["ItemID"],
                            SaleID = (int)reader["SaleID"],
                            BatchID = (int)reader["BatchID"],
                            Quantity = (decimal)reader["Quantity"],
                            UnitPrice = (decimal)reader["UnitPrice"],

                        };

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<SaleItem> GetAllSaleItems(int SaleID)
        {

            List<SaleItem> items = new List<SaleItem>();

            string query = @"SELECT * FROM SaleItems
                                WHERE SaleID = @SaleID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", SaleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new SaleItem
                                {
                                    SaleID = reader.GetInt32(reader.GetOrdinal("SaleID")),
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    BatchID = reader.GetInt32(reader.GetOrdinal("BatchID")),
                                    Quantity = reader.GetDecimal(reader.GetOrdinal("Quantity")),
                                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"))
                                });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return items;

        }

    }
}
