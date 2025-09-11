using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Test_Type
{
    public partial class FrmTakeTest : Form
    {
        private int _AppointmentID;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _Test;


        public FrmTakeTest(int AppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;

        }
        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            FillTestCardBeforeTesting();
        }
        public void FillTestCardBeforeTesting()
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;
            ctrlSecheduledTest1.LoadInfo(_AppointmentID);


            if (ctrlSecheduledTest1.TestAppointmentID != -1)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;

            int _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1) // So He has Old Test
            {
                _Test = clsTest.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                txtNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
                _Test = new clsTest(); // So I add a new Test object
        }

        public void AddTest()
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWrtittenTest_Click(object sender, EventArgs e)
        {

        }
    }
}
