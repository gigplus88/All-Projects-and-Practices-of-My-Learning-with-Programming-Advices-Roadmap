using DVLD.Properties;
using DVLD.Test_Type;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        clsTestAppointment _TestAppointment;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;

                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }
        private void _RenameColumns()
        {
            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }
        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            //Load Info By Test Type
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvLicenseTestAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();

            _RenameColumns();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null) //Means that not have a test yet
            {
                FrmScheduleTest frm1 = new FrmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retake it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To retatke test
            FrmScheduleTest frm2 = new FrmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);
            //---


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScheduleTest frm = new FrmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((DateTime)dgvLicenseTestAppointments.CurrentRow.Cells[1].Value > DateTime.Now)
            {
                MessageBox.Show("Your Appointments Date is Not yet", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);

            if (_TestAppointment.IsLocked)
            {
                MessageBox.Show("This Appointments is Locked , Create another Test Appointments", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmTakeTest frm = new FrmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void cmsAppointments_Opening(object sender, CancelEventArgs e)
        {
            bool IsLoked = (bool)dgvLicenseTestAppointments.CurrentRow.Cells[3].Value;
            DateTime dt = (DateTime)dgvLicenseTestAppointments.CurrentRow.Cells[1].Value;

            if (IsLoked)
            {
                TakeTestToolStripMenuItem.Enabled = editToolStripMenuItem.Enabled = !IsLoked;
                return;
            }
            TakeTestToolStripMenuItem.Enabled = !(dt > DateTime.Now);

        }

        private void ctrlDrivingLicenseApplication1_Load(object sender, EventArgs e)
        {

        }
    }
}
