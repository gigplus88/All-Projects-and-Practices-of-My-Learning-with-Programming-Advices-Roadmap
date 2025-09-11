using DVLD.Global_Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class FrmUpateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;

        public FrmUpateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            this._TestTypeID = TestTypeID;
        }

        private void FrmUpateTestType_Load(object sender, EventArgs e)
        {
            _GetTestTypeInfo(_TestTypeID);
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FilTestTypeInfoAfterEdit(clsTestType.enTestType TestTypeID)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription = txtDescription.Text.Trim();
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show($"Test Type  with ID =[{_TestType.ID}] Updated Successfully", "Update Test Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _TestTypeID = _TestType.ID;
            }
            else
            {
                MessageBox.Show($"Error  to Update  This Test data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void _GetTestTypeInfo(clsTestType.enTestType ID)
        {
            _TestType = clsTestType.Find((clsTestType.enTestType)ID);
            if (_TestType == null)
            {

                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblTestypeID.Text = ((int)_TestType.ID).ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();

            txtTitle.Focus();
        }
        public void UpdateTestTypeInfo(clsTestType.enTestType TestTypeID)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FilTestTypeInfoAfterEdit(_TestTypeID);
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                epUpdateTestType.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                epUpdateTestType.SetError(txtTitle, null);
            }
            ;
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                epUpdateTestType.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                epUpdateTestType.SetError(txtDescription, null);
            }
            ;

        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                epUpdateTestType.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                epUpdateTestType.SetError(txtFees, null);
            }


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                epUpdateTestType.SetError(txtFees, "Invalid Number.");
                return;
            }
            else
            {
                epUpdateTestType.SetError(txtFees, null);
            }


            if (Convert.ToSingle(txtFees.Text.Trim()) < 0)
            {
                e.Cancel = true;
                epUpdateTestType.SetError(txtFees, "Fees cannot be inferior of 0!");
                return;
            }
            else
            {
                epUpdateTestType.SetError(txtFees, null);
            }

        }
    }
}
