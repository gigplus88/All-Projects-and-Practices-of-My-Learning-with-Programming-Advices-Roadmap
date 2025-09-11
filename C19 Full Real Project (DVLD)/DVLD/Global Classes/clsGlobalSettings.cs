using DVLD_Business;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public class clsGlobalSettings
    {
        public static string filePath = "CurrentUser.txt";


        //New
        public static clsUser CurrentUser;
        public static string Version;


        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            //Save Login Data in txt File// 

            //try
            //{
            //    //this will get the current project directory folder.
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //    // Define the path to the text file where you want to save the data
            //    string filePath = currentDirectory + "\\data.txt";

            //    //incase the username is empty, delete the file
            //    if (Username=="" && File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //        return true;

            //    }

            //    // concatinate username and password with seperator.
            //    string dataToSave = Username + "#//#"+Password;

            //    // Create a StreamWriter to write to the file
            //    using (StreamWriter writer = new StreamWriter(filePath))
            //    {
            //        // Write the data to the file
            //        writer.WriteLine(dataToSave);

            //        return true;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //    return false;
            //}




            // Save Data in My_Data Key In Registry

            //by using statment but by simple other code is very quick
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName1 = "UserName", valueName2 = "Password";

            try
            {

                if (Username == "" || Password == "")
                {

                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(keyPath, true);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error to clear Current Key : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        Registry.SetValue(keyPath, valueName1, Username, RegistryValueKind.String);
                        Registry.SetValue(keyPath, valueName2, Password, RegistryValueKind.String);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error to Add Current Key : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }

}
