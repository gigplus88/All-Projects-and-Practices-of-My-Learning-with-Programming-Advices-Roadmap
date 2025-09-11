using DVLD.Applications.Local_Driving_License;
using DVLD.License;
using DVLD.Tests;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class FrmLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;

        public FrmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RenameColumns()
        {
            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 150;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 350;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 150;
            }
        }
        public void _RefreshData()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            lblNumberOfLocalDrivingLicenseApplications.Text = _dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();

            _RenameColumns();
        }
        private void FrmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        public void Validation()
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            // Check None Showing
            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblNumberOfLocalDrivingLicenseApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            // Other Showing
            if (FilterColumn == "LocalDrivingLicenseApplicationID")

                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());


            lblNumberOfLocalDrivingLicenseApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "L.D.L App ID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterBy.Visible = (cbFilterBy.Text != "None");

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = string.Empty;
                txtFilterBy.Focus();
            }

            _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblNumberOfLocalDrivingLicenseApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frmNewLocalDrivingLicenseApplication =
                new frmAddUpdateLocalDrivingLicesnseApplication();
            frmNewLocalDrivingLicenseApplication.ShowDialog();
            FrmLocalDrivingLicenseApplications_Load(null, null);
        }

        int LDLAppID;

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to  Cancel This Application", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Cancel())
                    {
                        MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //refresh the form again.
                        FrmLocalDrivingLicenseApplications_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not cancel application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void dgvLocalDrivingLicenseApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow selectedRow = dgvLocalDrivingLicenseApplications.Rows[e.RowIndex];

                LDLAppID = Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            }
            //CheckTestResult();
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UpdateButtonsForPersonApplicant()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            sechduleTestsToolStripMenuItem.Enabled = true;

        }
        void UpdateButtonsForDriverPerson()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;
        }

        int AppID;
        private void _ScheduleTest(clsTestType.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
            //refresh
            FrmLocalDrivingLicenseApplications_Load(null, null);

        }
        private void secheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void secheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void secheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssueDriverLicense frm = new FrmIssueDriverLicense((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FrmLocalDrivingLicenseApplications_Load(null, null);

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID
                ((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                FrmShowLicenseInfo frm = new FrmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).ApplicantPersonID;
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm =
                new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value); //for LDLAppID
            frm.ShowDialog();
            FrmLocalDrivingLicenseApplications_Load(null, null);

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            FrmLocalDrivingLicenseApplications_Load(null, null);

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            else
            {
                int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Delete())
                    {
                        MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmLocalDrivingLicenseApplications_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void cmsLocalDrivingLicenseApplication_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued(); // Is More than check if he has License and check if it s active

            // For Issue License button
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3 && !LicenseExists);

            // For Edit Button and For schedule tests  Buttons
            editApplicationToolStripMenuItem.Enabled = (!LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New));

            sechduleTestsToolStripMenuItem.Enabled = (!LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New));
            // For Showing License Button 
            showLicenseToolStripMenuItem.Enabled = LicenseExists;

            // For cancel New App
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            // Delete New Application
            deleteApplicationToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);


            // Know if He passed three Tests or no m Qnd Generate schedule buttons by this result

            bool VisionTestPassed = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool WrittenTestPassed = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool StreetTestPassed = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            //sechduleTestsToolStripMenuItem.Enabled = (!VisionTestPassed || !WrittenTestPassed || !StreetTestPassed) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                secheduleVisionTestToolStripMenuItem.Enabled = !VisionTestPassed;
                secheduleWrittenTestToolStripMenuItem.Enabled = VisionTestPassed && !WrittenTestPassed;
                secheduleStreetTestToolStripMenuItem.Enabled = VisionTestPassed && WrittenTestPassed && !StreetTestPassed;
            }
        }
    }
}
