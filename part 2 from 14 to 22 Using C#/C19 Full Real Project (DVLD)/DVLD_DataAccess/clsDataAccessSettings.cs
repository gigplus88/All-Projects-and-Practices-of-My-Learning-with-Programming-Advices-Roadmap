using System.Configuration;

namespace DVLD_DataAccess
{
    internal class clsDataAccessSettings
    {

        // public static string ConnectionString = "Server=.;Database=DVLD; User Id=sa;Password=sa1234;";

        //Connection with App.config

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


    }

}
