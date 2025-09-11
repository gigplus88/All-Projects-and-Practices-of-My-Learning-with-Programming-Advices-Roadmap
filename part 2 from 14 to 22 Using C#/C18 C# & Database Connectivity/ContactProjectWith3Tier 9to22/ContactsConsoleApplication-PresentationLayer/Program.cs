using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsoleApplication_PresentationLayer
{
    internal class Program
    {
        static void TestFindContact(int ID)
        {
            if (clsContact.IsContactExist(ID))
            {
                Console.WriteLine("Yes the Contact is there");
                clsContact Contact1 = clsContact.Find(ID);

                if (Contact1 != null)
                {
                    Console.WriteLine($"Contact Name:{Contact1.FirstName} {Contact1.LastName}");
                    Console.WriteLine($"Contact Email:{Contact1.Email} ");
                    Console.WriteLine($"Contact Phone:{Contact1.Phone} ");
                    Console.WriteLine($"Contact Address:{Contact1.Address} ");
                    Console.WriteLine($"Contact DateOfBirth:{Contact1.DateOfBirth} ");
                    Console.WriteLine($"Contact CountryID:{Contact1.CountryID} ");
                    Console.WriteLine($"Contact ImagePath:{Contact1.ImagePath} ");

                }
            }
            
            else
            {
                Console.WriteLine($"Contact By ContactID = {ID} not Found");
            }
        }
        static void TestAddNewContact()
        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "shyd@gmail.com";
            Contact1.Phone = "0634342783";
            Contact1.Address = "adress1";
            Contact1.ImagePath = "";
            Contact1.DateOfBirth = new DateTime(1977 , 11 , 6 , 10 ,30 ,0);
            Contact1.CountryID = 1;

            if (Contact1.Save())
            {
                Console.WriteLine($"Contact Added Succecfully with ContactID = { Contact1.ID}");
            }

            else
            {
                Console.WriteLine($"Contact not  Added Succecfully {Contact1.ID}");

            }
        }
        static void TestUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Contact1.FirstName = "Fadi";
                Contact1.LastName = "Maher";
                Contact1.Email = "shyd@gmail.com";
                Contact1.Phone = "0634342783";
                Contact1.Address = "adress1";
                Contact1.ImagePath = "";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
            }
            if (Contact1.Save())
            {
                Console.WriteLine($"Contact Updated Succecfully with ContactID = {Contact1.ID}");
            }

            else
            {
                Console.WriteLine($"Contact not  Updated Succecfully");

            }


            
        }
        static void TestDeleteContact(int ID)
        {
            if (clsContact.IsContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine($"The contact with ID = {ID} is Deleted");
                }
                else
                {
                    Console.WriteLine($"The contact with ID = {ID} is not Deleted");

                }
            }
            else
            {
                Console.WriteLine("No the ContactID = " +ID +" is not Found");

            }




        }
        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data");

            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{ row["ContactID"]} ,{row["FirstName"]} , {row["LastName"]} , {row["Email"]} , {row["Phone"]}" +
                $"{row["Address"]} , {row["DateOfBirth"]} , {row["CountryID"]} , {row["ImagePath"]}");

              
            }
        }
        static void TestIsContactExist(int ID)
        {
            if (clsContact.IsContactExist( ID))
            {
                Console.WriteLine("Yes the Contact is there");
            }

            else
            {
                Console.WriteLine("No the Contact is not there");

            }
        }




        static void TestFindCountryByID(int ID)
        {
            clsCountry Country1 = clsCountry.Find(ID);
            if (clsCountry.IsCountryExistByID(ID))
            {
                Console.WriteLine("Yes the Country is there");
                if (Country1 != null)
                {
                    Console.WriteLine($"CountryName:{Country1.CountryName}");
                    Console.WriteLine($"Code:{Country1.Code}");
                    Console.WriteLine($"PhoneCode:{Country1.PhoneCode}");
                }
            }

            else
            {
                Console.WriteLine($"CountryName By ContactID = {ID} not Found");
            }
        }
        static void TestFindCountryByName(string  CountryName)
        {
            clsCountry Country1 = clsCountry.Find(CountryName);
            if (clsCountry.IsCountryExistByName(CountryName))
            {
                Console.WriteLine("Yes the Country is there");

                if (Country1 != null)
                {
                    Console.WriteLine($"CountryID:{Country1.ID}");
                    Console.WriteLine($"Code:{Country1.Code}");
                    Console.WriteLine($"PhoneCode:{Country1.PhoneCode}");

                }
            }

            else
            {
                Console.WriteLine($"CountryName By CountryID = {Country1.ID} not Found");
            }
        }


        static void TestAddNewCountry()
        {
            clsCountry Country1 = new clsCountry();

            Country1.CountryName = "Syrie";
            Country1.Code = "234";
            Country1.PhoneCode = "998";

            if (Country1.Save())
            {
                Console.WriteLine($"Country Added Succecfully with CountryID = {Country1.ID}");
            }

            else
            {
                Console.WriteLine($"Country not  Added Succecfully ");

            }
        }
        static void TestUpdateCountry(int ID)
        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                Country1.CountryName = "Frensh";
                Country1.Code = "234";
                Country1.PhoneCode = "213";


            }
            if (Country1.Save())
            {
                Console.WriteLine($"Country Updated Succecfully with CountryID = {Country1.ID}");
            }

            else
            {
                Console.WriteLine($"Country not  Updated Succecfully");

            }



        }
        static void TestDeleteCountry(int ID)
        {
            if (clsCountry.IsCountryExistByID(ID))
            {
                
                if (clsCountry.DeleteCountry(ID))
                {
                    Console.WriteLine($"The Country with ID = {ID} is Deleted");
                }
                else
                {
                    Console.WriteLine($"The Country with ID = {ID} is not Deleted");

                }
            }
            else
            {
                Console.WriteLine("No the CountryID = " +ID +" is not Found");

            }




        }
        static void ListCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Countries Data");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]} ,{row["CountryName"]}");

            }
        }


        static void TestIsCountryExistByID(int ID)
        {
            if (clsCountry.IsCountryExistByID(ID))
            {
                Console.WriteLine("Yes the Country is there");
            }

            else
            {
                Console.WriteLine("No the Country is not there");

            }
        }
        static void TestIsCountryExistByName(string CountryName)
        {
            if (clsCountry.IsCountryExistByName(CountryName))
            {
                Console.WriteLine("Yes the Country is there");
            }

            else
            {
                Console.WriteLine("No the Country is not there");

            }
        }

        static void Main(string[] args)
        {
            //TestFindContact(200);
            //TestAddNewContact();
            //TestUpdateContact(1);
            //TestDeleteContact(100);
            //ListContacts();
            //TestIsContactExist(8);


            //TestFindCountryByID(2);
            //TestFindCountryByName("Canada");

            //TestIsCountryExistByID(6);
            //TestAddNewCountry();
            //TestUpdateCountry( 5);
            //TestDeleteCountry(8);
            //ListCountries();

            TestIsCountryExistByName("Mali");
            //TestIsCountryExistByID(7);

        }
    }
}
