using DVLD_Business;
using System;
using System.Windows.Forms;


namespace DVLD.Test_Type
{
    public partial class FrmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;

        public FrmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._TestTypeID = TestTypeID;
            this._AppointmentID = AppointmentID;
        }

        public FrmScheduleTest()
        {
            InitializeComponent();

        }

        private void FrmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
