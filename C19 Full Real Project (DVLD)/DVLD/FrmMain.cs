using DVLD.Applications;
using DVLD.License;
using DVLD.Users;
using DVLD_Business;
using System;
using System.Windows.Forms;


namespace DVLD
{
    public partial class FrmMain : Form
    {
        string UserName;
        FrmLogin _frmLogin;
        public enum enApplicationTypeID
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementforALostDL = 3,
            ReplacementforADamagedDL = 4,
            ReleaseDetainedDL = 5,
            NewInternationalLicense = 6,
            ReatkeTest = 8
        }

        public static enApplicationTypeID ApplicationTypeID;
        public FrmMain()
        {
            InitializeComponent();
        }
        public FrmMain(FrmLogin frm)
        {
            InitializeComponent();
            this._frmLogin = frm;
        }
        public FrmMain(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblWelcomeMessage.Text = clsGlobalSettings.CurrentUser.UserName;
            lblVersion.Text = "DVLD " + clsGlobalSettings.Version;
        }

        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmManagePeople frm = new FrmManagePeople();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void accountSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmManageUsers frm = new FrmManageUsers();
            frm.ShowDialog();
        }

        int UserID;
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserID = clsGlobalSettings.CurrentUser.UserID;
            clsUser _User = clsUser.Find(UserID);

            if (_User != null)
            {
                FrmUserInfo frmUserInfo = new FrmUserInfo(UserID);
                frmUserInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry User not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chqngePqsszordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void applicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tsmManageApplicationTypes_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frm = new FrmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void tsmManageTestTypes_Click(object sender, EventArgs e)
        {
            FrmListTestType frm = new FrmListTestType();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
        }

        private void localDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingLicenseApplications frm = new FrmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListDrivers listDrivers = new FrmListDrivers();
            listDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewInternationalLicenseApplication frm = new FrmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInternationalDrivingLicenseApplications frm = new FrmInternationalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRenewLocalDrivingLicense frm = new FrmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void deplacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReplacementForDamagedLicense frm = new FrmReplacementForDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainLicense frm = new FrmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainedLicensesList frm = new FrmDetainedLicensesList();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingLicenseApplications frm = new FrmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
