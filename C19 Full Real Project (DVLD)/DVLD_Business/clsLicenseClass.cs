using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public int LicenseClasseID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;
        public clsLicenseClass()
        {
            this.LicenseClasseID = 0;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;

            Mode = enMode.AddNew;

        }
        public clsLicenseClass(int LicenseClasseID, string ClasseName, string ClasseDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClasseID = LicenseClasseID;
            this.ClassName = ClasseName;
            this.ClassDescription = ClasseDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;

        }
        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = ""; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }
        public static clsLicenseClass Find(string ClasseName)
        {
            int LicenseClasseID = 0;
            string ClasseDescription = "";
            byte DefaultValidityLength = 10, MinimumAllowedAge = 18;
            float ClassFees = 0;

            bool IsFound = clsLicenseClassData.GetApplicationTypeInfoByClassName(ClasseName, ref LicenseClasseID, ref ClasseDescription, ref MinimumAllowedAge,
                ref DefaultValidityLength, ref ClassFees);

            if (IsFound)
            {
                return new clsLicenseClass(LicenseClasseID, ClasseName, ClasseDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }

            else
            {
                return null;
            }
        }
        private bool _AddNewLicenseClass()
        {

            this.LicenseClasseID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);


            return (this.LicenseClasseID != -1);
        }

        private bool _UpdateLicenseClass()
        {

            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClasseID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }

            return false;
        }


        public static int GetMinimumAllowedAgeByLicenseClassID(int LicenseClassID)
        {
            return clsLicenseClassData.GetMinimumAllowedAgeByLicenseClassID(LicenseClassID);

        }
    }
}
