using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsPerson
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + "" + LastName; }
        }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public int NationalityCountryID { get; set; }
        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsCountry CountryInfo;

        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;

        public clsPerson()
        {
            this.PersonID = 0;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = -1;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;

        }



        public clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo,
             DateTime DateOfBirth, short Gender, string Address, string Email, string Phone, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gender;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }


        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo,
              this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.NationalityCountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    _UpdatePerson();
                    return true;
            }
            return false;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo,
               this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.NationalityCountryID, this.ImagePath);

            return this.PersonID != -1;
        }

        public static bool DeletePerson(int PersonID)
        {
            return (clsPersonData.DeletePerson(PersonID));

        }

        public static bool IsPersonExist(int PersonID)
        {
            return (clsPersonData.IsPersonExist(PersonID));

        }

        public static bool IsPersonExist(string NationalNo)
        {
            return (clsPersonData.IsPersonExist(NationalNo));

        }


        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }


        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInfoByID
                                (
                                    PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Email, ref Phone,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", Phone = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            int NationalityCountryID = -1, PersonID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo,
            ref DateOfBirth, ref Gender, ref Address, ref Email, ref Phone, ref NationalityCountryID, ref ImagePath);


            if (IsFound)
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo,
                DateOfBirth, Gender, Address, Email, Phone, NationalityCountryID, ImagePath);
            }

            else
            {
                return null;
            }
        }



    }
}
