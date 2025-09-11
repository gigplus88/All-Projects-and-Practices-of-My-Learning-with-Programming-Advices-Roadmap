using System;
using System.Data;
using System.Runtime.CompilerServices;
using ContactsDataAccessLayer;
using static ContactsBusinessLayer.clsContact;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public enMode Mode = enMode.AddNew;

        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.ImagePath = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            Mode = enMode.AddNew;

        }
        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address
            , DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            Mode = enMode.Update;
        }
        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (clsContactDataAccess.GetContatctInfoByID(ref ID, ref FirstName, ref LastName, ref Email,
            ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName, Email,
             Phone, Address, DateOfBirth, CountryID, ImagePath);

            }

            else
            {
                return null;
            }
        }
        private bool _AddNewContact()
        {
            this.ID = clsContactDataAccess.AddnewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                this.DateOfBirth, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }
        private bool _UpdateContact()
        {

            return clsContactDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                this.DateOfBirth, this.CountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;

                    }
                case enMode.Update:

                    return _UpdateContact();

            }
            return false;

        }

        public static bool DeleteContact(int ID)
        {
            return (clsContactDataAccess.DeleteContact(ID));

        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }

        public static bool IsContactExist(int ID)
        {
            return clsContactDataAccess.IsContactExist(ID);
        }
    }

    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public enMode Mode = enMode.AddNew;

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName =  "";
            this.Code = "";
            this.PhoneCode = "";
            Mode = enMode.AddNew;

        }
        private clsCountry(int ID, string CountryName , string Code , string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;
        }
        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            string Code = "";
            string PhoneCode = "";
            if (clsCountryDataAccess.GetCoutryInfoByID(ref ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName,  Code,  PhoneCode);

            }

            else
            {
                return null;
            }
        }
        public static clsCountry Find(string CountryName)
        {
            int ID = 0;
            string Code = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCoutryInfoByName(ref ID, ref CountryName , ref Code , ref PhoneCode ))
            {
                return new clsCountry(ID, CountryName,  Code,  PhoneCode);

            }

            else
            {
                return null;
            }
        }
        private bool _AddNewCountry()
        {
            this.ID = clsCountryDataAccess.AddnewCountry(this.CountryName , this.Code , this.PhoneCode);

            return (this.ID != -1);
        }
        private bool _UpdateCountry()
        {
            return clsCountryDataAccess.UpdateCountry(this.ID, this.CountryName , this.Code , this.PhoneCode);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;

                    }
                case enMode.Update:

                        return _UpdateCountry();

            }
            return false;

        }
        public static bool DeleteCountry(int ID)
        {
            return (clsCountryDataAccess.DeleteCountry(ID));

        }
        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static bool IsCountryExistByID(int ID)
        {
            return clsCountryDataAccess.IsCountryExistByID(ID);
        }
        public static bool IsCountryExistByName(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExistByName(CountryName);
        }

    }
}
