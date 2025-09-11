using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public string FullName, ClassName;
        public int LDLAppID;
        private int _ApplicantPersonID = -1;


        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationBasicInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationBasicInfoCard();
        }
        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblAppType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedBy.Text = "[????]";

        }

        void _FillApplicationBasicInfoCard()
        {
            _ApplicantPersonID = _Application.ApplicantPersonID;

            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblAppType.Text = _Application.ApplicationTypeInfo.ApplicationTitle;
            lblApplicant.Text = _Application.FullName;
            lblApplicationDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

            FullName = lblApplicant.Text.Trim();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(_ApplicantPersonID);
            frmPersonDetails.ShowDialog();
        }

        private void gpDLAI_Enter(object sender, EventArgs e)
        {

        }
    }
}
