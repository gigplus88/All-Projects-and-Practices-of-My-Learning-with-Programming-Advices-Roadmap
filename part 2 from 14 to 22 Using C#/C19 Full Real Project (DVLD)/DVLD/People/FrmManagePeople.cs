using DVLD.License;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmManagePeople : Form
    {
        private clsPerson _Person;

        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        public FrmManagePeople()
        {
            InitializeComponent();
            txtFilterBy.Visible = false;
            _RefreshData();
        }

        private void _RefreshData()
        {
            //dgvPoeple.DataSource = clsPerson.GetAllPeople();
            //lblNumberOfPeople.Text = clsPerson.CountPeople().ToString();



            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gendor", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople.DefaultView;
            lblNumberOfPeople.Text = _dtAllPeople.Rows.Count.ToString();


        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() != "Person ID")
            {
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Filtering()
        {
            cbFilterItem = cbFilterBy.SelectedItem.ToString().Trim();
            string Input = txtFilterBy.Text.Trim();
            switch (cbFilterItem)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "FirstName":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "Nationality";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            // If I don t filter
            if (cbFilterItem == "None" || FilterColumn == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblNumberOfPeople.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            // Filtering With Person ID or other

            if (FilterColumn == "PersonID")
            {
                if (string.IsNullOrWhiteSpace(txtFilterBy.Text))
                {
                    _dtPeople.DefaultView.RowFilter = "";
                    lblNumberOfPeople.Text = dgvPeople.Rows.Count.ToString();
                    return;
                }
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            }

            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            lblNumberOfPeople.Text = dgvPeople.Rows.Count.ToString();
        }
        string cbFilterItem = "", FilterColumn;


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                return;
            }
            txtFilterBy.Visible = true;
            txtFilterBy.Focus();

        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            frm.ShowDialog();
            _RefreshData();
        }
        private void _RenameHeader()
        {
            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;

            }
        }
        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _RefreshData();

            // For Rename Header Names
            _RenameHeader();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            if (MessageBox.Show($"Are you want to Delete Person [{(int)dgvPeople.CurrentCell.Value}]", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonDetails frm = new FrmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            frm.ShowDialog();
            _RefreshData();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        int PersonID;
        private void dgvPoeple_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow selectedRow = dgvPeople.Rows[e.RowIndex];

                PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);
            }
        }

        private void dgvPoeple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory frm = new FrmLicenseHistory((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
