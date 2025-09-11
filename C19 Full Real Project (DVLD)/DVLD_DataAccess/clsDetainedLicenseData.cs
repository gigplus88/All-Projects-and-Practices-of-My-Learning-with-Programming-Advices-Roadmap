using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool GetLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses Where DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)(reader["DetainDate"]);
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)(reader["IsReleased"]);

                    if (reader["ReleaseDate"] == DBNull.Value)
                    {
                        ReleaseDate = DateTime.MaxValue;
                    }
                    else
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }


                    if (reader["ReleasedByUserID"] == DBNull.Value)
                    {
                        ReleasedByUserID = -1;
                    }
                    else
                    {
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }


                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        ReleaseApplicationID = -1;
                    }
                    else
                    {
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
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
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
        ref int DetainID, ref DateTime DetainDate,
        ref float FineFees, ref int CreatedByUserID,
        ref bool IsReleased, ref DateTime ReleaseDate,
        ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetDetainedLicensesList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            /*"select DetainedLicenses.DetainID  as 'D.ID',DetainedLicenses.LicenseID as 'L.ID' ,  
                         DetainedLicenses.DetainDate as 'D.Date'  , DetainedLicenses.IsReleased as 'Released' , 
                         DetainedLicenses.FineFees as 'Fine Fees' , DetainedLicenses.ReleaseDate as 'Release Date' , 
                         People.NationalNo as 'N.No', People.FirstName + ' '+ People.SecondName+ ' '+ People.ThirdName +' '+ People.LastName 
                         as 'FullName' , DetainedLicenses.ReleaseApplicationID as 'Release App.ID' from DetainedLicenses join 
                         Licenses on 
                         DetainedLicenses.LicenseID = Licenses.LicenseID join 
                         Applications on 
                         Licenses.ApplicationID = Applications.ApplicationID join 
                         People on 
                         People.PersonID = Applications.ApplicantPersonID 
                         order by IsReleased ,DetainID;  "*/
            string query = @"select * from detainedLicenses_View order by IsReleased ,DetainID;";

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
        public static bool UpdateToReleasedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @" Update  DetainedLicenses 
                            set LicenseID = @LicenseID,
                             DetainDate = @DetainDate,
                             FineFees = @FineFees,
                             CreatedByUserID = @CreatedByUserID,
                             where DetainID = @DetainID ;";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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

            return (RowsAffected > 0);


        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "INSERT INTO DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)" +
                           "VALUES(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,0)" +
                           " SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
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

            return DetainID;
        }


        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
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


            return IsDetained;
            ;

        }

        public static bool ReleaseDetainedLicense(int DetainID,
                int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleasedByUserID = @ReleasedByUserID,
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

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

            return (rowsAffected > 0);
        }

























        public static DateTime GetDetainDate(int DetainID)
        {
            DateTime DetainDate = DateTime.Now;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select DetainDate from DetainedLicenses where DetainID =@DetainID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    DetainDate = Convert.ToDateTime(result);
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

            return DetainDate;
        }
        public static int GetDetainIDByLicenseID(int LicenseID)
        {
            int DetainID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select DetainID from DetainedLicenses where DetainDate = " +
                "(select max(DetainDate) from DetainedLicenses where LicenseID =  @LicenseID); ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
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

            return DetainID;

        }
        public static bool IsDetainedLicense(int LicenseID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select IsReleased from DetainedLicenses where" +
                " DetainDate = (select max(DetainDate) from DetainedLicenses where LicenseID =  @LicenseID)";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    if (Convert.ToByte(result) == 0)
                    {
                        IsFound = true;
                    }
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

            return IsFound;
        }
        public static bool LicenseReleased(int DetainID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "UPDATE DetainedLicenses  SET [IsReleased] = 1  where DetainID =@DetainID ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
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

            return (RowsAffected > 0);

        }
        public static DataTable DetainedLicensesTable = new DataTable();
        public static DataView DetainedLicensesView = new DataView();

        public static int CountDetainedLicenses()
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "";

            return DetainedLicensesView.Count;
        }
        public static DataView FindByByDetainID(int DetainID)
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "D.ID=" + DetainID;

            return DetainedLicensesView;
        }
        public static DataView FindByByReleasedLicense(byte Released)
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "Released=" + Released;
            //DetainedLicensesView.RowFilter ="Is Released="+ (Released == 1 ? "True" : "False");
            return DetainedLicensesView;
        }
        public static DataView FindByNationalNo(string NationalNo)
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "N.No='" + NationalNo + "'";

            return DetainedLicensesView;
        }
        public static DataView FindByFullName(string FullName)
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "FullName='" + FullName + "'";

            return DetainedLicensesView;
        }
        public static DataView FindByReleaseAppID(int ReleaseAppID)
        {
            DetainedLicensesTable = GetDetainedLicensesList();

            DetainedLicensesView = DetainedLicensesTable.DefaultView;

            DetainedLicensesView.RowFilter = "Release App.ID=" + ReleaseAppID;

            return DetainedLicensesView;
        }
    }
}
