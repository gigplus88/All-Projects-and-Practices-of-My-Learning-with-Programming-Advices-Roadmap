using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class FrmManageUsers : Form
    {
        private static DataTable _dtAllUser = clsUser.GetAllUsers();
        public FrmManageUsers()
        {
            InitializeComponent();
        }
        void _RenameColumns()
        {
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 120;
            }
        }
        public void _RefreshData()
        {
            dgvUsers.DataSource = _dtAllUser;
            cbFilterBy.SelectedIndex = 0;
            lblNumberOfUsers.Text = _dtAllUser.Rows.Count.ToString();

            _RenameColumns();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frm = new FrmAddEditUser();
            frm.ShowDialog();
            _RefreshData();

        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.SelectedItem.ToString() == "Is Active")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return;
            }
            else
            {
                txtFilterBy.Visible = !(cbFilterBy.Text == "None");
                cbIsActive.Visible = false;

                txtFilterBy.Text = "";
                txtFilterBy.Focus();
                return;
            }

        }


        public void Filtering()
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUser.DefaultView.RowFilter = "";
                lblNumberOfUsers.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            lblNumberOfUsers.Text = dgvUsers.Rows.Count.ToString();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterBy = cbIsActive.Text;

            switch (FilterBy)
            {
                case "All":
                    break;
                case "Yes":
                    FilterBy = "1";
                    break;
                case "No":
                    FilterBy = "0";
                    break;
            }


            if (FilterBy == "All")
                _dtAllUser.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterBy);

            lblNumberOfUsers.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frm = new FrmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //_RefreshData();
            FrmManageUsers_Load(null, null);
        }

        int PersonID, UserID;
        //Other Solution to get UserID;
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

                UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frm = new FrmAddEditUser();
            frm.ShowDialog();
            _RefreshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfo frm = new FrmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User hqs been Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmManageUsers_Load(null, null);
            }
            else
                MessageBox.Show("User is not deleted due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
