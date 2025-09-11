using DVLD.Users;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmAddEditUser : Form
    {
        static private int _PersonID = 0;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUser _User;
        public FrmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        //public FrmAddEditUser(int PersonID)
        //{
        //    InitializeComponent();
        //    _PersonID = PersonID;
        //}
        public FrmAddEditUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                //ctrlPersonCardWithFilter1.FilterEnabled = false;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                //tcUserInfo.SelectedTab = tpLoginInfo;
                return;
            }

            if (/*ctrlPersonCardWithFilter1.PersonID!=-1*/1 == 1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                    //tcUserInfo.SelectedTab = tpLoginInfo;

                }
            }

            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ctrlPersonCardWithFilter1.FilterFocus();

            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string Input = txtUserName.Text;
            if (string.IsNullOrEmpty(Input))
            {
                e.Cancel = true;
                epUser.SetError(txtUserName, "UserName cannot be blank");
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(Input))
                {
                    e.Cancel = true;
                    epUser.SetError(txtUserName, "username is used by another user");
                    return;
                }
                else
                {
                    e.Cancel = false;
                    epUser.SetError(txtUserName, "");
                }
            }
            else
            {
                if (Input != _User.UserName)
                {
                    if (clsUser.IsUserExist(Input))
                    {
                        e.Cancel = true;
                        epUser.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        e.Cancel = false;
                        epUser.SetError(txtUserName, "");
                    }
                }

            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                epUser.SetError(txtPassword, "Password cannot be blank");
                return;
            }
            else
            {
                e.Cancel = false;
                epUser.SetError(txtPassword, "");

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                epUser.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                e.Cancel = false;
                epUser.SetError(txtConfirmPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chbIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Old Solution
            //if (clsUser.Mode == clsUser.enMode.AddNew)
            //{
            //    _AddUser();
            //}
            //else
            //{
            //    FillUserInfoAfterEdit(_PersonID);
            //}
        }
        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        private void _AddUser()
        {
            /*clsUser*/
            _User = new clsUser();
            _User.PersonID = 1; // ctrlPersonCardWithFilter1._PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            if (chbIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive = false;

            }
            if (_User.Save())
            {
                MessageBox.Show($"{_User.UserID} Added Successfully", "Adding User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _UserID = _User.UserID;
                lblUserID.Text = _UserID.ToString();

                FrmManageUsers frmManageUsers = new FrmManageUsers();
                frmManageUsers._RefreshData();
                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show($"Error  to Add {_User.UserID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void _FillBoxes(int PersonID)
        {
            _User = clsUser.FindByPersonID(PersonID);

            if (_User == null)
            {
                return;
            }
            if (FindMode == enMFindMode.BeforeFill)
            {
                lblUserID.Text = _User.UserID.ToString();
                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                if (_User.IsActive == true)
                {
                    chbIsActive.Checked = true;
                }
                else
                {
                    chbIsActive.Checked = false;
                }

                FindMode = enMFindMode.AfterFill;
            }
            else
            {
                FillUserInfoAfterEdit(PersonID);
            }
        }
        public void FillUserInfoAfterEdit(int PersonID)
        {
            /* clsUser*/
            _User = clsUser.FindByPersonID(PersonID);
            if (_User == null)
            {
                MessageBox.Show($"User with ID =[{PersonID}] not Found", "Update User", MessageBoxButtons.OK);
                return;
            }
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            if (chbIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive = false;
            }

            clsUser.Mode = clsUser.enMode.Update;

            if (_User.Save())
            {
                MessageBox.Show($"{_User.PersonID} Updated Successfully", "Update User", MessageBoxButtons.OK);
                _PersonID = _User.PersonID;
            }
        }
        public void UpdateUser(int PersonID)
        {
            lblTitle.Text = "Update User";
            //ctrlPersonCardWithFilter1.PersonSearchToEdit(PersonID);
            _FillBoxes(PersonID);
        }


        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;

                //ctrlPersonCardWithFilter1.FilterFocus();
            }

            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                txtUserName.Focus();
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chbIsActive.Checked = true;
        }
        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);
            //ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chbIsActive.Checked = _User.IsActive;
            //ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
            {
                _LoadUserInfo();
            }
        }

        //private void FrmAddEditUser_Activated(object sender, EventArgs e)
        //{
        //    ctrlPersonCardWithFilter1.FilterFocus();
        //}
    }
}
