using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class FrmListDrivers : Form
    {
        private DataTable _dtAllDrivers;
        public FrmListDrivers()
        {
            InitializeComponent();
        }
        private void _RenameColumns()
        {
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }
        }
        private void _RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllDrivers = clsDriver.GetAllDriversInfo();

            dgvDrivers.DataSource = _dtAllDrivers;
            lblNumberOfRecords.Text = dgvDrivers.Rows.Count.ToString();

            _RenameColumns();
        }
        private void ListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFilterBy.Text != "None");


            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Enabled = false;
            }
            else
                txtFilterBy.Enabled = true;

            txtFilterBy.Text = "";
            txtFilterBy.Focus();

        }

        public void Filtering()
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            lblNumberOfRecords.Text = _dtAllDrivers.Rows.Count.ToString();
        }




        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonDetails frm = new FrmPersonDetails((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            ListDrivers_Load(null, null);
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");

            //FrmInternationalInfoDriver frm = new FrmInternationalInfoDriver();
            //frm.ShowDialog();
            //ListDrivers_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory frm = new FrmLicenseHistory((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            ListDrivers_Load(null, null);

        }
    }
}
