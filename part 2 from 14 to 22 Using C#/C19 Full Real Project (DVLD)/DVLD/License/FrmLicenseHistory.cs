using System;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class FrmLicenseHistory : Form
    {
        private int _PersonID = -1;

        public FrmLicenseHistory()
        {
            InitializeComponent();

        }
        public FrmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void FrmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(32);
            frmShowLicenseInfo.ShowDialog();
        }

        private void ctrlPersonCardWithFilter1_OnLicenseSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
            {
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
        }
    }
}

