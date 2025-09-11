using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class FrmIssueDriverLicense : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public FrmIssueDriverLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void FillPersonDataForIssue()
        {
            txtNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            // Check if he has Application for this License
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            else
            {
                //Check if All Tests Passed
                if (!_LocalDrivingLicenseApplication.PassedAllTests())
                {
                    MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                //Check if he has This License yet
                int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
                if (LicenseID != -1)
                {
                    MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;

                }
            }

            ctrlDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

        }
        private void FrmIssueDriverLicense_Load(object sender, EventArgs e)
        {
            FillPersonDataForIssue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), clsGlobalSettings.CurrentUser.UserID);

            // Handle if it issued or not
            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
