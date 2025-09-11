using DVLD.Global_Classes;
using DVLD.License;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class FrmNewInternationalLicenseApplication : Form
    {
        private int _InternationalLicenseID = -1;

        public FrmNewInternationalLicenseApplication()
        {
            InitializeComponent();

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SaveApplicationInfo()
        {

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees;
            InternationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;



            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssueUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lbLInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo InternationalDriverInfo = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            InternationalDriverInfo.ShowDialog();
        }


        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }


        void FillInfoCardBeforeApplication()
        {
            lblAppliocationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblAppliocationDate.Text.Trim();
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

        }
        private void FrmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            FillInfoCardBeforeApplication();
        }
       

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            llblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                btnIssue.Enabled = false;

                return;
            }




            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llblShowLicensesInfo.Enabled = true;
                btnIssue.Enabled = false;

                return;
            }

            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llblShowLicensesInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }

        public void ResetDefaultValue()
        {
            ctrlDriverLicenseInfoWithFilter1.ResetDefaultValue();
            ctrlDriverLicenseInfoWithFilter1.Focus();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            llblShowLicensesInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;

            ResetDefaultValue();
        }

        private void Issue_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            SaveApplicationInfo();

            btnReset.Enabled = true;
            btnIssue.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowLicensesInfo.Enabled = true;

        }

        private void FrmNewInternationalLicenseApplication_Shown(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.TxtFocus = true;
        }
    }
}
