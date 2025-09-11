using DVLD.Controls;
using DVLD.Global_Classes;
using DVLD.License;
using DVLD_Business;
using System;
using System.Windows.Forms;



namespace DVLD.Applications
{
    public partial class FrmReleaseDetainedLicense : Form
    {

        private int _SelectedLicenseID = -1;

        public FrmReleaseDetainedLicense()
        {
            InitializeComponent();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }

        public FrmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ReleaseLicense()
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobalSettings.CurrentUser.UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Failed to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;

            btnReset.Enabled = true;

        }


        private void btnRelease_Click(object sender, EventArgs e)
        {
            ReleaseLicense();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(_SelectedLicenseID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llblShowLicensesHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            llblShowLicenseInfo.Enabled = true;
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();


            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            lblCreatedBy.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
            btnReset.Enabled = true;
        }

        public void ResetDefaultValue()
        {
            ctrlDriverLicenseInfoWithFilter1.ResetDefaultValue();
            ctrlDriverLicenseInfoWithFilter1.Focus();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnRelease.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;


            lblDetainDate.Text = "[?????]";
            lblDetainID.Text = "[?????]";
            lblLicenseID.Text = "[?????]";
            lblFineFees.Text = "[?????]";
            lblTotalFees.Text = "[?????]";
            lblApplicationFees.Text = "[?????]";
            lblApplicationID.Text = "[?????]";

            btnRelease.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;


            ResetDefaultValue();
        }
        private void FrmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.InputText == "")
            {
                llblShowLicenseInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                btnRelease.Enabled = false;
            }

        }

        private void FrmReleaseDetainedLicense_Shown(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }
    }
}
