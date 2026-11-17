using System;
using System.IO;
using System.Windows.Forms;

namespace POS.Helpers
{
    public class Util
    {
        private static readonly string ImagesFolder = Path.Combine(Application.StartupPath, "POS-Images");

        public static string GenerateGUID()
        {
            // convert the GUID to a string
            return Guid.NewGuid().ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        private static bool CopyImage(ref string sourceFile, string folderName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFile) ||
                    !File.Exists(sourceFile))
                    return false;

                string destinationFolder =
                    Path.Combine(ImagesFolder, folderName);

                if (!CreateFolderIfDoesNotExist(destinationFolder))
                    return false;

                string destinationFile = Path.Combine(
                    destinationFolder,
                    ReplaceFileNameWithGUID(sourceFile)
                );

                File.Copy(sourceFile, destinationFile);

                sourceFile = destinationFile;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool CopyProductImage(ref string sourceFile)
        {
            return CopyImage(ref sourceFile, "Products");
        }

        public static bool CopyUserImage(ref string sourceFile)
        {
            return CopyImage(ref sourceFile, "Users");
        }

        public static bool CopyLogo(ref string sourceFile)
        {
            return CopyImage(ref sourceFile, "Settings");
        }

        public static bool DeleteImage(string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagePath))
                    return false;

                if (File.Exists(imagePath))
                    File.Delete(imagePath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
