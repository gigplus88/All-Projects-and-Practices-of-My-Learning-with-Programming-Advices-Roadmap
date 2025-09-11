using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsTestType
    {
        public clsTestType.enTestType ID { set; get; } // Because the ID of Test is Between 1 and 3
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;
        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;

            Mode = enMode.AddNew;
        }
        public clsTestType(clsTestType.enTestType ID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            Mode = enMode.Update;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        private bool _AddNewTestType()
        {
            this.ID = (clsTestType.enTestType)clsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "");
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    _UpdateTestType();
                    return true;
            }
            return false;
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float TestTypeFees = 0;

            bool IsFound = clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees);

            if (IsFound)
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;
        }
        public static float GetTestFeesByTypeID(int TestTypeID)
        {
            return clsTestTypeData.GetTestFeesByTypeID(TestTypeID);
        }

    }
}
