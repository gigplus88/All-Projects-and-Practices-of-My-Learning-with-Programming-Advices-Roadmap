using DVLD.Global_Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmUpdateApplicationType : Form
    {
        private clsApplicationType _ApplicationType;
        private int _ApplicationTypeID = 0;

        public FrmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            this._ApplicationTypeID = ApplicationTypeID;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UpdateApplicationTypeInfo()
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.ApplicationTitle = txtTitle.Text.Trim();
            _ApplicationType.ApplicationFees = Convert.ToSingle(txtFees.Text.Trim());


            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateApplicationTypeInfo();
        }

        private void LoadDataToEdit()
        {
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();

            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                txtTitle.Text = _ApplicationType.ApplicationTitle;
                txtFees.Text = _ApplicationType.ApplicationFees.ToString();
            }
            txtTitle.Focus();
        }
        private void FrmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadDataToEdit();
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                epUpdateApplicationType.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                epUpdateApplicationType.SetError(txtTitle, null);
            }
            ;
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                epUpdateApplicationType.SetError(txtFees, "Fees cannot be empty!");
            }
            else
            {
                epUpdateApplicationType.SetError(txtFees, null);
            }
            ;

            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                epUpdateApplicationType.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                epUpdateApplicationType.SetError(txtFees, null);
            }
            ;
        }
    }
}
