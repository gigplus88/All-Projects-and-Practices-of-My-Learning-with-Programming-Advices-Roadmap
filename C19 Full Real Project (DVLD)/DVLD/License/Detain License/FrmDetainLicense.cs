using DVLD.Controls;
using DVLD.Global_Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace DVLD.License
{
    public partial class FrmDetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public FrmDetainLicense()
        {
            InitializeComponent();
            //ctrlDriverLicenseInfoWithFilter.TextBoxTextChanged += ctrlDriverLicenseInfoWithFilter_TextBoxTextChanged; ;
        }

        void FillDetainInfoCard()
        {
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
            llblShowLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;
        }
        private void FrmDetainLicense_Load(object sender, EventArgs e)
        {
            FillDetainInfoCard();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void ctrlLicenseInfo1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            llblShowLicenseInfo.Enabled = llblShowLicensesHistory.Enabled = (_SelectedLicenseID != -1);
            
            // Check if License Exist
            if (_SelectedLicenseID == -1)
            {
                return;
            }

            // Check if Is License Detained
            if (ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llblShowLicenseInfo.Enabled = true;
                llblShowLicensesHistory.Enabled = true;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
            
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }
            


            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Input.");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(txtFineFees, null);
            }
            
        }

        public void ResetDefaultValue()
        {
            ctrlDriverLicenseInfoWithFilter.ResetDefaultValue();
            ctrlDriverLicenseInfoWithFilter.Focus();
            ctrlDriverLicenseInfoWithFilter.FilterEnabled = true;
        }
      
        private void btnReset_Click(object sender, EventArgs e)
        {

            lblDetainID.Text = "[?????]";
            lblLicenseID.Text = "[?????]";
            txtFineFees.Text = "";
            txtFineFees.Enabled = true;


            btnDetain.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;


            ResetDefaultValue();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(_SelectedLicenseID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobalSettings.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);



            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter.FilterEnabled = false;
            txtFineFees.Enabled = false;
            llblShowLicenseInfo.Enabled = true;

            btnReset.Enabled = true;
        }

        private void FrmDetainLicense_Shown(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter.txtLicenseIDFocus();
            llblShowLicensesHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            btnDetain.Enabled = false;
            btnReset.Enabled = false;
        }


       

        private void ctrlDriverLicenseInfoWithFilter_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter.InputText == "")
            {
                llblShowLicenseInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                btnDetain.Enabled=false;
            }
            
        }
    }
}
