using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS_DataAccess.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public Settings Get()
        {
            const string query = @"SELECT StoreName, StorePhone, StoreAddress, CurrencySymbol, TaxRate,
                                          LowStockThreshold, AllowNegativeStock, ReceiptFooter
                                     FROM Settings WHERE SettingID = 1;";

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return new Settings
                    {
                        StoreName = (string)reader["StoreName"],
                        StorePhone = reader["StorePhone"] as string,
                        StoreAddress = reader["StoreAddress"] as string,
                        CurrencySymbol = (string)reader["CurrencySymbol"],
                        TaxRate = (decimal)reader["TaxRate"],
                        LowStockThreshold = (decimal)reader["LowStockThreshold"],
                        ReceiptFooter = reader["ReceiptFooter"] as string,
                        LastModified = DateTime.Now
                    };
                }
            }
        }
        public bool Update(Settings settings)
        {
            int rowsAffected = 0;

            const string query = @"UPDATE Settings
                                      SET StoreName = @StoreName, 
                                          StorePhone = @StorePhone,
                                          StoreAddress = @StoreAddress, 
                                          CurrencySymbol = @CurrencySymbol,
                                          TaxRate = @TaxRate, 
                                          LowStockThreshold = @LowStockThreshold,
--                                          AllowNegativeStock = @AllowNegativeStock, 
                                          ReceiptFooter = @ReceiptFooter,
                                          LastModified = GETDATE()
                                    WHERE SettingID = 1;";

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StoreName", settings.StoreName);
                command.Parameters.AddWithValue("@StorePhone", (object)settings.StorePhone ?? DBNull.Value);
                command.Parameters.AddWithValue("@StoreAddress", (object)settings.StoreAddress ?? DBNull.Value);
                command.Parameters.AddWithValue("@CurrencySymbol", settings.CurrencySymbol);
                command.Parameters.AddWithValue("@TaxRate", (object)settings.TaxRate ?? DBNull.Value);
                command.Parameters.Add("@LowStockThreshold", SqlDbType.Decimal).Value = settings.LowStockThreshold;
                command.Parameters.AddWithValue("@ReceiptFooter", (object)settings.ReceiptFooter ?? DBNull.Value);

                connection.Open();

               rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0);

            }
        }

    }

}
