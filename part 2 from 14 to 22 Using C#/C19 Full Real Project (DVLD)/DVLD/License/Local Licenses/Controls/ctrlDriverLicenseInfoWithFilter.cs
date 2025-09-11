using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
            txtLicenseID.TextChanged += TextBoxTextChanged;

        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        private bool _TxtFocus = true;
        public bool TxtFocus
        {
            get
            {
                return _TxtFocus;
            }
            set
            {
                _TxtFocus = value;
                if (_TxtFocus)
                {
                    txtLicenseID.Focus();
                }
            }
        }

        public string InputText
        {
            get { return txtLicenseID.Text; }
        }
        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return driverLicenseInfo1.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return driverLicenseInfo1.SelectedLicenseInfo; } }

        public void ResetDefaultValue()
        {
            txtLicenseID.Text = "";
            driverLicenseInfo1.ResetDefaultValue();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            driverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = driverLicenseInfo1.LicenseID;
            // When I Load LicenseID info I send This LicenseID to OnLicenseSelected event
            // I 
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);
        }

        private void btnFilterByLicenseID_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {

                btnFilterByLicenseID.PerformClick();
            }
        }
        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }
        public bool txtLicenseIDEmpty()
        {
            if (string.IsNullOrEmpty( txtLicenseID.Text ) )
            {
                return true;
            }
            return false;

        }
        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }
        public event EventHandler TextBoxTextChanged;
        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged?.Invoke(this , e);

        }
    }
    
   

}
