using DVLD.Applications;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class FrmDetainedLicensesList : Form
    {
        private DataTable _dtDetainedLicenses = clsDetainedLicense.GetDetainedLicenseList();

        public FrmDetainedLicensesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RenameColumns()
        {
            //_dtDetainedLicenses = clsDetainedLicense.GetDetainedLicenseList();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblNumberOfDetainedLicenses.Text = _dtDetainedLicenses.Rows.Count.ToString();

                if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }
        }
        public void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;


            _RenameColumns();
        }
        private void FrmListDetainedlLicenses_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //is good than searching with DriverID Because I want the info of this License 
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            FrmPersonDetails frm = new FrmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            FrmLicenseHistory frm = new FrmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            FrmDetainLicense frm = new FrmDetainLicense();
            frm.ShowDialog();
            RefreshData();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
            RefreshData();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            RefreshData();
        }

        public void Filtering()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;


                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }



            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblNumberOfDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")

                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            lblNumberOfDetainedLicenses.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }


        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    
                    
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }*/

            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;
                cbIsReleased.Visible = false;
            }
            else
            {
                if (cbFilterBy.Text == "Is Released")
                {
                    txtFilterBy.Visible = false;
                    cbIsReleased.Visible = true;
                    cbIsReleased.Focus();
                    cbIsReleased.SelectedIndex = 0;
                }
                else
                {
                    txtFilterBy.Visible = true;
                    cbIsReleased.Visible = false;
                    txtFilterBy.Text = "";
                    txtFilterBy.Focus();
                }
            }
        }



        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicenseInfo frm = new FrmShowLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !((bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value);
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblNumberOfDetainedLicenses.Text = _dtDetainedLicenses.DefaultView.Count.ToString();

        }
    }
}
