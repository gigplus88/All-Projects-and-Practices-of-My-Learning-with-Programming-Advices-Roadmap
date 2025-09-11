using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;


namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContatctInfoByID(ref int ID , ref string FirstName , ref string LastName , ref string Email ,
            ref string Phone , ref string Address , ref DateTime DateOfBirth , ref int CountryID , ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Contacts " +
                         "  Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }

                    else
                    {
                        ImagePath = "";
                    }
                }


                else
                {
                    isFound = false;
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {

                connection.Close();

            } 

                return isFound;

        }


        public static int AddnewContact( string FirstName,  string LastName,  string Email,
             string Phone,  string Address,  DateTime DateOfBirth,  int CountryID,  string ImagePath)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = "INSERT INTO Contacts(FirstName ,LastName,Email ,Phone ,Address,DateOfBirth, CountryID , ImagePath)" +
                " VALUES (@FirstName ,@LastName,@Email ,@Phone ,@Address,@DateOfBirth, @CountryID , @ImagePath) " +
                "SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if ("ImagePath" !="")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally 
            { 
                connection.Close(); 
            }

            return ContactID;

        }

        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email,
             string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = " Update  Contacts " 
                            + "set FirstName = @FirstName,"
                            + "LastName = @LastName,"
                            + "Email = @Email,"
                            + "Phone = @Phone,"
                            + "Address = @Address,"
                            + "DateOfBirth = @DateOfBirth,"
                            + "CountryID = @CountryID,"
                            + "ImagePath = @ImagePath"
                            + " where ContactID = @ContactID ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if ("ImagePath" !="")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (RowsAffected>0);

           
        }

        public static bool DeleteContact(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "DELETE FROM Contacts" +
                             " WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                RowsAffected =  command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
               Console.WriteLine("EArror " + ex.Message);
            }

            finally
            {
                connection.Close();
            }
            return (RowsAffected>0);

            //return RowsAffected;
        }

        public static DataTable GetAllContacts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "Select * From Contacts";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
             
            }
            finally 
            { 
                connection.Close(); 
            }
            return dt;
        }

        public static bool IsContactExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found=1 FROM Contacts " +
                         "  Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
                
                // My Solution
                //object result = command.ExecuteScalar(); 

                    //if (result != null)
                    //{
                    //    isFound = true;
                    //}
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return isFound;

        }
    }

    public class clsCountryDataAccess
    {
        public static bool GetCoutryInfoByID(ref int ID, ref string CountryName, ref string Code, ref string PhoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Countries " +
                         "  Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CountryName = (string)reader["CountryName"];

                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }

                    else
                    {
                        Code = "";
                    }


                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }

                    else
                    {
                        PhoneCode = "";
                    }

                }


                else
                {
                    isFound = false;
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {

                connection.Close();

            }

            return isFound;

        }
        public static bool GetCoutryInfoByName(ref int ID, ref string CountryName, ref string Code, ref string PhoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Countries " +
                         "  Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);
            


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["CountryID"];
                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }

                    else
                    {
                        Code = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }

                    else
                    {
                        PhoneCode = "";
                    }
                }


                else
                {
                    isFound = false;
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {

                connection.Close();

            }

            return isFound;

        }

        public static int AddnewCountry(string CountryName, string Code , string PhoneCode)
        {
            int CountryID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = "INSERT INTO Countries(CountryName , Code , PhoneCode)" +
                " VALUES (@CountryName , @Code , @PhoneCode)  SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@PhoneCode", PhoneCode);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    CountryID = InsertedID;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return CountryID;

        }
        public static bool UpdateCountry(int ID, string CountryName , string Code , string PhoneCode)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = " Update  Countries "
                            + "set CountryName = @CountryName , "
                            +"Code = @Code ,"
                            +"PhoneCode = @PhoneCode  "
                            +" where CountryID = @CountryID ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@PhoneCode", PhoneCode);


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (RowsAffected>0);
        }
        public static bool DeleteCountry(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "DELETE FROM Countries" +
                             " WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                RowsAffected =  command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

            finally
            {
                connection.Close();
            }
            return (RowsAffected>0);

            //return RowsAffected;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "Select * From Countries";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool IsCountryExistByID(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found=1 FROM Countries " +
                         "  Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

                // My Solution
                //object result = command.ExecuteScalar(); 

                //if (result != null)
                //{
                //    isFound = true;
                //}
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return isFound;

        }
        public static bool IsCountryExistByName(string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found=1 FROM Countries " +
                           "Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

                // My Solution
                //object result = command.ExecuteScalar(); 

                //if (result != null)
                //{
                //    isFound = true;
                //}
            }

            catch (Exception ex)
            {
                isFound = false;
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return isFound;

        }


    }

}
