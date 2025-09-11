using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = 0;
            CountryName = "";
        }

        public clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryNameByCountryID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }

            else
            {
                return null;
            }
        }
        public static clsCountry Find(string CountryName)
        {
            int CountryID = 0;

            if (clsCountryData.GetCountryIDByCountryName(ref CountryID, CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }

            else
            {
                return null;
            }
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }


    }
}
