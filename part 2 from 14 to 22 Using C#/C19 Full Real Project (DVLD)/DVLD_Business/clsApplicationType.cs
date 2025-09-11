using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTitle { get; set; }
        public float ApplicationFees { get; set; }

        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;
        public clsApplicationType()
        {
            this.ApplicationTypeID = 0;
            this.ApplicationTitle = "";
            this.ApplicationFees = 0;
            Mode = enMode.AddNew;

        }
        public clsApplicationType(int ApplicationID, string Title, float Fees)
        {
            this.ApplicationTypeID = ApplicationID;
            this.ApplicationTitle = Title;
            this.ApplicationFees = Fees;
            Mode = enMode.Update;

        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationsTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTitle, this.ApplicationFees);
        }
        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationsTypeData.AddNewApplicationType(this.ApplicationTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationsTypeData.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ApplicationID)
        {
            string Title = "";
            float Fees = 0;

            bool IsFound = clsApplicationsTypeData.GetApplicationTypeInfoByID(ref ApplicationID, ref Title, ref Fees);

            if (IsFound)
            {
                return new clsApplicationType(ApplicationID, Title, Fees);
            }

            else
            {
                return null;
            }
        }
        public static float GetApplicationFeesByApplicationTypeID(int ApplicationTypeID)
        {
            return clsApplicationsTypeData.GetApplicationFeesByApplicationTypeID(ApplicationTypeID);
        }
        public static string GetApplicationTypeNameByApplicationTypeID(int ApplicationTypeID)
        {
            return clsApplicationsTypeData.GetApplicationTypeNameByApplicationTypeID(ApplicationTypeID);
        }

    }
}
