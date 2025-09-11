using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public clsLicense LicenseInfo { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { set; get; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUserInfo { set; get; }

        public int ReleaseApplicationID { get; set; }

        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }
        public clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
                               int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.LicenseInfo = clsLicense.Find(LicenseID);
            this.DetainDate = DateTime.Now;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.Find(this.CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleasedByUserInfo = clsUser.FindByPersonID(this.ReleasedByUserID);
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    _UpdateApplication();
                    return true;
            }
            return false;
        }
        private bool _UpdateApplication()
        {
            return clsDetainedLicenseData.UpdateToReleasedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
        }


        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            return this.DetainID != -1;
        }
        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = 0, CreatedByUserID = 0;
            int ReleasedByUserID = 0, ReleaseApplicationID = 0;
            DateTime DetainDate = DateTime.Now;
            DateTime ReleaseDate = DateTime.Now;
            bool IsReleased = false;
            float FineFees = 0;

            bool IsFound = clsDetainedLicenseData.GetLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
            ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsFound)
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }

            else
            {
                return null;
            }
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID,
            ref DetainID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense(DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

        public static DataTable GetDetainedLicenseList()
        {
            return clsDetainedLicenseData.GetDetainedLicensesList();
        }



















        public static bool IsDetainedLicense(int LicenseID)
        {
            return (clsDetainedLicenseData.IsDetainedLicense(LicenseID));

        }
        public static int GetDetainIDByLicenseID(int DetainID)
        {
            return (clsDetainedLicenseData.GetDetainIDByLicenseID(DetainID));
        }
        public static bool LicenseReleased(int DetainID)
        {
            return (clsDetainedLicenseData.LicenseReleased(DetainID));

        }
        public static DateTime GetDetainDate(int DetainID)
        {
            return (clsDetainedLicenseData.GetDetainDate(DetainID));

        }

        public static int CountDetainedLicenses()
        {
            return clsDetainedLicenseData.CountDetainedLicenses();
        }
        public static DataView FindByByDetainID(int DetainID)
        {
            return clsDetainedLicenseData.FindByByDetainID(DetainID);
        }
        public static DataView FindByByReleasedLicense(byte Released)
        {
            return clsDetainedLicenseData.FindByByReleasedLicense(Released);
        }
        public static DataView FindByNationalNo(string NationalNo)
        {
            return clsDetainedLicenseData.FindByNationalNo(NationalNo);
        }
        public static DataView FindByFullName(string FullName)
        {
            return clsDetainedLicenseData.FindByFullName(FullName);
        }
        public static DataView FindByReleaseAppID(int ReleaseAppID)
        {
            return clsDetainedLicenseData.FindByReleaseAppID(ReleaseAppID);
        }
    }
}
