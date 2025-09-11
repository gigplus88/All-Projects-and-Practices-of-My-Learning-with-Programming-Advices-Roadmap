using DVLD.Global_Classes;
using DVLD.License;
using DVLD_Business;
using System;
using System.Windows.Forms;


namespace DVLD.Applications
{
    public partial class FrmRenewLocalDrivingLicense : Form
    {
        private int _NewLicenseID = -1;


        public FrmRenewLocalDrivingLicense()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void FillInfoBeforeRenew()
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            llblShowLicensesHistory.Enabled = false;
            llblShowLicensesInfo.Enabled = false;
            btnRenew.Enabled = false;

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }
        private void FrmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            FillInfoBeforeRenew();
        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(_NewLicenseID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            _NewLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            llblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            // If LicenseID not found or is txtFilter empty
            if (SelectedLicenseID == -1)
            {
                btnRenew.Enabled = false;
                return;
            }

            int DefaultValidityLength = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            //check the license is not Active.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            //check the license is not Expired.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expired, it will expire on: " + clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

           

            btnRenew.Enabled = true;

        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }
        public void ResetDefaultValue()
        {
            ctrlDriverLicenseInfoWithFilter1.ResetDefaultValue();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
        }
        void SaveRenewApplication()
        {

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                RenewLicense(txtNotes.Text.Trim(), clsGlobalSettings.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnRenew.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowLicensesInfo.Enabled = true;

            btnReset.Enabled = true;

        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            SaveRenewApplication();

        }

        private void FrmRenewLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            llblShowLicensesInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;

            lblRLApplicationID.Text = "[?????]";
            lblRenewedLicenseID.Text = "[?????]";
            lblExpirationDate.Text = "[?????]";
            lblLicenseFees.Text = "[?????]";
            lblTotalFees.Text = "[?????]";
            txtNotes.Text = "";
            txtNotes.Enabled = true;




            ResetDefaultValue();

        }

        private void FrmRenewLocalDrivingLicense_Shown(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.TxtFocus = true;
        }
    }
}
