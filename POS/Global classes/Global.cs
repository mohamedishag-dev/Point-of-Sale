using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace POS.Global_classes
{
    public static class Global
    {
        private const string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\POS_App";
        private const string Username = "Username";
        private const string Password = "Password";

        private static bool RegisterLogIn(string Username)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\LoginRegister.txt";


                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "  -  " + DateTime.Now.ToString();


                // Create a New Line to AppendAllText to the file
                File.AppendAllText(filePath, dataToSave + Environment.NewLine);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
                return false;
            }
        }
        public static bool SaveRememberedUser(string username, string password)
        {
            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, Username, username, RegistryValueKind.String);
                Registry.SetValue(keyPath, Password, password, RegistryValueKind.String);
                RegisterLogIn(username);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string username, ref string password)
        {
            try
            {
                // Read the value to the Registry
                string valueUserName = Registry.GetValue(keyPath, Username, null) as string;
                string valuePassword = Registry.GetValue(keyPath, Password, null) as string;

                if (valueUserName != null && valuePassword != null)
                {
                    username = valueUserName;
                    password = valuePassword;
                    return true;
                }
                username = "";
                password = "";

                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
                return false;
            }

        }


    }
}

