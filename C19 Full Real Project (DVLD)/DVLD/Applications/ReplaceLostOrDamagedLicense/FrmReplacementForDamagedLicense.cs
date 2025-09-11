using DVLD.Controls;
using DVLD.Global_Classes;
using DVLD.License;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static DVLD_Business.clsLicense;

namespace DVLD.Applications
{
    public partial class FrmReplacementForDamagedLicense : Form
    {
        private int _NewLicenseID = -1;

        public FrmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        void FillFirstLicenseInfo()
        {
            lblAppliocationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

            llblShowLicensesHistory.Enabled = false;
            llblShowNewLicensesInfo.Enabled = false;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
            rbdamagedLicense.Checked = true;
        }
        private void FrmReplacementForDemagedLicense_Load(object sender, EventArgs e)
        {
            FillFirstLicenseInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SavedApplicationInfo()
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobalSettings.CurrentUser.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblLRApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblReplacedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);



            btnIssueReplacement.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowNewLicensesInfo.Enabled = true;

            btnReset.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SavedApplicationInfo();

        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(_NewLicenseID);
            frmShowLicenseInfo.ShowDialog();
        }


        private int _GetApplicationTypeID()
        {

            if (rbdamagedLicense.Checked)

                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {

            if (rbdamagedLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }


        private void rbdamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }


        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void ctrlLicenseInfo1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            btnIssueReplacement.Enabled = true;
        }

        private void FrmReplacementForDamagedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        public void ResetDefaultValue()
        {
            ctrlDriverLicenseInfoWithFilter1.ResetDefaultValue();
            ctrlDriverLicenseInfoWithFilter1.TxtFocus = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            rbdamagedLicense.Checked = true;
            btnIssueReplacement.Enabled = false;
            llblShowNewLicensesInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;


            llblShowNewLicensesInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;

            lblOldLicenseID.Text = "[?????]";
            lblLRApplicationID.Text = "[?????]";
            lblReplacedLicenseID.Text = "[?????]";


            ResetDefaultValue();
        }

        private void ctrlDriverLicenseInfoWithFilter1_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.InputText == "")
            {
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                btnIssueReplacement.Enabled = false;
            }
        }
    }
}
