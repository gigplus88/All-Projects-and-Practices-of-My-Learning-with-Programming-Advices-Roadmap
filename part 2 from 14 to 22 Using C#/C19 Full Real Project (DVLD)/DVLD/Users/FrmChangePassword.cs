using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmChangePassword : Form
    {
        private int _UserID = -1;

        private clsUser _User;
        public FrmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        private void _ResetDefualtValues()
        {
            ctrlUserCard1.ResetPersonInfo();
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        public void LoadUserInfo(int UserID)
        {
            ctrlUserCard1.LoadUserInfo(UserID);
        }
        public void LoadUserInfo(string UserName)
        {
            ctrlUserCard1.LoadUserInfo(UserName);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                epPassword.SetError(txtCurrentPassword, "Current Pqsszord cannot be blank");
                return;
            }
            else
            {
                epPassword.SetError(txtCurrentPassword, null);
            }
            ;


            if (txtCurrentPassword.Text != _User.Password)
            {
                e.Cancel = true;
                epPassword.SetError(txtCurrentPassword, "Current Password is Wrong!");
            }
            else
            {
                e.Cancel = false;
                epPassword.SetError(txtCurrentPassword, "");
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show($"Password change Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                epPassword.SetError(txtNewPassword, "New Password cannot be blank");
                return;
            }
            else
            {
                epPassword.SetError(txtNewPassword, null);
            }
            ;

            if (txtNewPassword.Text == txtCurrentPassword.Text)
            {
                e.Cancel = true;
                epPassword.SetError(txtNewPassword, " Error,Your New Password is the same of Current password");
            }
            else
            {
                epPassword.SetError(txtNewPassword, null);
            }
            ;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                epPassword.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                epPassword.SetError(txtConfirmPassword, null);
            }
            ;
        }
    }
}
